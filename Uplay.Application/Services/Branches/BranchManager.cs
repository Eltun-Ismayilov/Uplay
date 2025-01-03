using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Companies;
using Uplay.Application.Models.Core.Branches;
using Uplay.Application.Services.AppFiles;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Enums;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Branches;

public class BranchManager : BaseManager, IBranchService
{
    private readonly IBranchRepository _branchRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public BranchManager(
        IMapper mapper,
        IUserRepository userRepository,
        IBranchRepository branchRepository,
        IHttpContextAccessor contextAccessor,
        IFileService fileService)
        : base(mapper, contextAccessor)
    {
        _userRepository = userRepository;
        _branchRepository = branchRepository;
        _fileService = fileService;
    }

    public async Task<ActionResult<int>> CreateBranchAsync(SaveBranchRequest command)
    {
        var userExist = await _userRepository.CheckUser(x => x.UserName == command.Username);
        var parentUser = await _userRepository.GetUserByUsername(Username);

        if (userExist is not null)
            throw new BadHttpRequestException("Daxil etdiyiniz Username ve ya Email ile bagli isdifadeci movcudur");

        var mapping = Mapper.Map<Branch>(command);

        mapping.Onwer = new User
        {
            Salt = Guid.NewGuid(),
            Name = "",
            Surname = "",
            Email = "",
            Phone = "",
            EmailConfirmed = true,
            UserName = command.Username,
        };

        mapping.BranchCategories =
            command.CategoryIds.Select(ctgId => new BranchCategory() { CategoryId = ctgId }).ToList();
        mapping.Tin = "";
        mapping.Status = AccauntStatusEnum.Active;
        mapping.CompanyBranches = new List<CompanyBranch>()
        {
            new()
            {
                Branch = mapping,
                CompanyId = parentUser.Companies.First().Id
            }
        };

        string passHash =
            AesOperation.ComputeSha256Hash(command.Password + mapping.Onwer.Salt);

        mapping.Onwer.Password = passHash;

        var operationId = Guid.NewGuid();

        var qrCodebyte = QrCodeExtension.GenerateQr($"https://localhost:7260/qr/:operationId?operationId={operationId}");//TODO

        var appFile = await _fileService.UploadPhoto(qrCodebyte);

        mapping.BranchQrCodes = new List<BranchQrCode>()
        {
            new BranchQrCode
            {
                AppFile = appFile,
                operationId = operationId
            }
        };

        var data = await _branchRepository.InsertAsync(mapping);

        return data;
    }

    public async Task<BranchGetAllResponse> GetAll(PaginationFilter paginationFilter)
    {
        BranchGetAllResponse response = new();
        var user = await _userRepository.GetUserByUsername(Username);
        if (user is null) throw new BadHttpRequestException("401");

        var faqQuery = _branchRepository.GetListQuery(user.Companies.First().Id);
        var list = await faqQuery.PaginatedMappedListAsync<BranchDto, Branch>(Mapper, paginationFilter.PageNumber,
            paginationFilter.PageSize);
        response.BranchDtos = list;

        return response;
    }

    public async Task<int> DeleteBranch(int id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);
        if (branch is null) throw new BadHttpRequestException("Branch not found");

        branch.Status = AccauntStatusEnum.Deleted;
        branch.Deleted = true;

        return await _branchRepository.SaveChangesAsync();
    }

    public async Task<int> DisableBranch(int id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);
        if (branch is null) throw new BadHttpRequestException("Branch not found");

        branch.Status = AccauntStatusEnum.Disabled;
        return await _branchRepository.SaveChangesAsync();
    }

    public async Task<CompanyDetailsDto> GetBranchByiD(int id)
    {
        var branch = await _branchRepository.GetQuery()
            .FirstOrDefaultAsync(x => x.Id == id);
            
        if (branch is null)
            throw new NotFoundException("Branch not found");

        return new CompanyDetailsDto()
        {
            Name = branch.Name,
            File = null
        };
    }

    public async Task<string> GetByBranchIdAsync(int id)
    {
        var branch =  _branchRepository.GetAllQuery()
                                       .Include(x=>x.BranchQrCodes)
                                       .First(x => x.Id == id);

        return HttpContextAccessor.GeneratePhotoUrl(branch.BranchQrCodes.First().AppFileId);
    }
}