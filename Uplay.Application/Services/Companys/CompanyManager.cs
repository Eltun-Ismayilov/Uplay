using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Models.Companies;
using Uplay.Application.Services.AppFiles;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Enum;
using Uplay.Persistence.Repository;
using Uplay.Persistence.Repository.Mongo;

namespace Uplay.Application.Services.Companys
{
    public class CompanyManager : BaseManager, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyBranchRepository _companyBranchRepository;
        private readonly IFileService _fileService;
        readonly IConfiguration _configuration;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IBranchQrCodeRepository _branchQrCodeRepository;
        private readonly IQrRetentionRepo _qrRetentionRepo;

        public CompanyManager(
            IMapper mapper,
            ICompanyRepository companyRepository,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            IBranchRepository branchRepository,
            ICompanyBranchRepository companyBranchRepository,
            IFileService fileService,
            IBranchQrCodeRepository branchQrCodeRepository,
            IQrRetentionRepo qrRetentionRepo)
            : base(mapper)
        {
            _companyRepository = companyRepository;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _branchRepository = branchRepository;
            _companyBranchRepository = companyBranchRepository;
            _fileService = fileService;
            _branchQrCodeRepository = branchQrCodeRepository;
            _qrRetentionRepo = qrRetentionRepo;
        }

        public async Task<ActionResult<int>> CreateCorporateAsync(SaveCompanyRequest command)
        {
            var users = await _userRepository.GetAllAsync();

            if (users.Any(x =>
                    x.UserName == command.Onwer.UserName || x.Email == command.Onwer.Email ||
                    x.UserName == command.Onwer.UserName))
                throw new BadHttpRequestException(
                    "Daxil etdiyiniz Username,Email ve ya UserName adinda isdifadeci movcudur");

            var mapping = Mapper.Map<Company>(command);

            mapping.Onwer.Salt = Guid.NewGuid();

            mapping.Onwer.EmailConfirmed = false;

            var randomValue = GenerateRandomSixDigitNumber();

            mapping.Onwer.OtpCode = randomValue;

            string passHash =
                AesOperation.ComputeSha256Hash(command.Onwer.Email + command.Onwer.Password + mapping.Onwer.Salt);

            mapping.Onwer.Password = passHash;

            var data = await _companyRepository.InsertAsync(mapping);

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:UserName"]));

            email.To.Add(MailboxAddress.Parse(command.Onwer.Email));

            email.Subject = _configuration["EmailSettings:displayName"];

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                { Text = $"Zehmet olmasa {randomValue} OTP codu ile girisivizi testiqleyin" };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailSettings:smtpServer"],
                Convert.ToInt32(_configuration["EmailSettings:smtpPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return data;
        }

        public async Task<ActionResult<int>> CreatePersonalAsync(SavePersonalRequest command)
        {
            var users = await _userRepository.GetAllAsync();

            if (users.Any(x =>
                    x.UserName == command.Onwer.UserName || x.Email == command.Onwer.Email ||
                    x.Phone == command.Onwer.Phone))
                throw new BadHttpRequestException(
                    "Daxil etdiyiniz Username,Email ve ya Nomre adinda isdifadeci movcudur");

            var mapping = Mapper.Map<Company>(command);

            mapping.Onwer.Salt = Guid.NewGuid();

            mapping.Onwer.EmailConfirmed = false;

            string passHash =
                AesOperation.ComputeSha256Hash(command.Onwer.Email + command.Onwer.Password + mapping.Onwer.Salt);

            mapping.Onwer.Password = passHash;

            var randomValue = GenerateRandomSixDigitNumber();

            mapping.Onwer.OtpCode = randomValue;

            var companyId = await _companyRepository.InsertAsync(mapping);

            var userId = await _companyRepository.GetByIdAsync(companyId);

            var brachCategory = command.CategoryIds.Select(ctgId => new BranchCategory() { CategoryId = ctgId })
                .ToList();

            var operationId = Guid.NewGuid();

            var qrCodebyte =
                QrCodeExtension.GenerateQr($"https://localhost:7260/qr/:operationId?operationId={operationId}");

            var appFile = await _fileService.UploadPhoto(qrCodebyte);

            var branch = new Branch
            {
                Name = command.BrandName,
                Tin = command.Tin,
                City = command.City,
                Location = command.Location,
                Status = AccauntStatusEnum.Active,
                OnwerId = userId.OnwerId,
                BranchCategories = brachCategory,
                BranchQrCodes = new List<BranchQrCode>()
                {
                    new BranchQrCode()
                    {
                        AppFile = appFile,
                        operationId = operationId,
                    }
                }
            };

            var brachId = await _branchRepository.InsertAsync(branch);

            await _companyBranchRepository.InsertAsync(new CompanyBranch { BranchId = brachId, CompanyId = companyId });

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:UserName"]));

            email.To.Add(MailboxAddress.Parse(command.Onwer.Email));

            email.Subject = _configuration["EmailSettings:displayName"];

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                { Text = $"Zehmet olmasa {randomValue} OTP codu ile girisivizi testiqleyin" };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailSettings:smtpServer"],
                Convert.ToInt32(_configuration["EmailSettings:smtpPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return brachId;
        }

        public async Task<ActionResult<int>> GetOperationId(Guid operationId)
        {
            var branchQrCode = _branchQrCodeRepository.GetQuery()
                .FirstOrDefault(x => x.operationId == operationId);
            
            if (branchQrCode is null)
                throw new NotFoundException("Branch Qr not found");

            await _qrRetentionRepo.WriteQrRetentionToCollection(branchQrCode.BranchId);

            return branchQrCode.BranchId;
        }

        public static int GenerateRandomSixDigitNumber()
        {
            Random random = new Random();

            return random.Next(100000, 999999 + 1);
        }
    }
}