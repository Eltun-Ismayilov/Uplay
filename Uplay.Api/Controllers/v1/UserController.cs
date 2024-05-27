//using AutoMapper;
//using Azure.Core;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Net.Mail;
//using System.Net;
//using System.Reactive;
//using Uplay.Application.Exceptions;
//using Uplay.Application.Extensions;
//using Uplay.Application.Models;
//using Uplay.Domain.Entities.Models.Users;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Uplay.Api.Controllers.v1
//{

//    public class UserController : BaseController
//    {
//        //[HttpPost("/api/PassReset/ResetPassword")]
//        //public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
//        //{
//        //    //ResetPasswordCommand command = _mapper.Map<ResetPasswordCommand>(resetPasswordDto);
//        //    //command.UserId = UserId;
//        //    // command.UserIp = UserIp;
//        //    // await _userService.ResetPassword(command);

//        //    //return Ok();

//        //    //var user = await _dbContext.Users.FindAsync(request.UserId);

//        //    //string passHash = AesOperation.ComputeSha256Hash(user.Email + request.OldPassword + user.Salt);

//        //    //if (user.Password != passHash)
//        //    //    throw new DefaultValidationException("Pass incorrect!");

//        //    //string newPasswordHash = AesOperation.ComputeSha256Hash(user.Email + request.NewPassword + user.Salt);

//        //    //user.Password = newPasswordHash;

//        //    //await _dbContext.SaveChangesAsync(CancellationToken.None);

//        //    //return Unit.Value;

//        //    //public class ResetPasswordDto 
//        //    //{
//        //    //    public string OldPassword { get; set; }
//        //    //    public string NewPassword { get; set; }

//        //    //    [Required(ErrorMessage = "ConfirmPassword must be not empty"), Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
//        //    //    public string ConfirmPassword { get; set; }
//        //    //}
//        //}


//        //[AllowAnonymous]
//        //[HttpPost("/api/PassReset/SetPass")]
//        //public async Task<IActionResult> PassResetSetPass(PassResetSetPassDto passResetSetPassDto)
//        //{
//        //    //PassResetSetPassCommand command = _mapper.Map<PassResetSetPassCommand>(passResetSetPassDto);
//        //    //command.UserIp = UserIp;

//        //    //await _userService.SetPassAsync(command);

//        //    //return Ok();
//        //    //Domain.User user = _dbContext.Users
//        //    //   .Include(e =>
//        //    //       e.UserTokens.Where(e => e.Value.ToString() == request.UserToken && e.UserTokenStatusId == 1))
//        //    //   .FirstOrDefault(e => e.Id == request.UserId && e.IsActive);

//        //    //if (user is null)
//        //    //    throw new NotFoundException(nameof(Domain.User), request.UserId);
//        //    //if (user.UserTokens.Count == 0)
//        //    //    throw new NotFoundException(nameof(request.UserToken), request.UserToken);

//        //    //string newPass = AesOperation.ComputeSha256Hash(user.Email + request.NewPass + user.Salt);
//        //    //user.Password = newPass;
//        //    //UserToken userToken = user.UserTokens.First();
//        //    //userToken.UserTokenStatusId = 3;
//        //    //userToken.UpdatedDate = DateTime.UtcNow.AddHours(4);

//        //    //await _dbContext.SaveChangesAsync(CancellationToken.None);

//        //    //return Unit.Value;
//        //    //    public class PassResetSetPassDto
//        //    //{
//        //    //    public int UserId { get; set; }
//        //    //    public string UserToken { get; set; }
//        //    //    public string NewPass { get; set; }
//        //    //}
//        //}

//        //[AllowAnonymous]
//        //[HttpPost("/api/PassReset/SendMail")]
//        //public async Task<IActionResult> PassResetGenerateToken(string mail)
//        //{
//        //    PassResetGenerateTokenCommand command = new PassResetGenerateTokenCommand
//        //    {
//        //        Email = mail,
//        //        LangId = LangId,
//        //        UserIp = UserIp,
//        //        Route = Request.Headers["Referer"].ToString()
//        //    };
//        //    await _userService.ResetPassGenerateTokenAsync(command);

//        //    return Ok();
//        //Domain.User user = _dbContext.Users
//        //       .Include(x => x.Employee).ThenInclude(x => x.EmployeeDocument)
//        //       .FirstOrDefault(e => e.IsActive && e.Email == request.Email);

//        //    if (user is null)
//        //        throw new DefaultValidationException($"User with email \"{request.Email}\" not exist");

//        //UserToken userToken = new UserToken
//        //{
//        //    Value = Guid.NewGuid(),
//        //    UserTokenTypeId = 1,
//        //    UserTokenStatusId = 1,
//        //    ExpireDate = DateTime.UtcNow.AddHours(4).AddDays(1),
//        //    CreatedIp = request.UserIp
//        //};

//        ////      UPDATE PREVIOUS TOKENS

//        //user.UserTokens.Add(userToken);

//        //    await _dbContext.SaveChangesAsync(CancellationToken.None);

//        //Uri uri = _uriService.GetPassResetUri(request.Route, userToken.Value.ToString()); --KOD ASAGDAKIDI{

//        //public class UriService
//        //{
//        //    private readonly string _baseUri;

//        //    public UriService(string baseUri) => _baseUri = baseUri;

//        //    public Uri GetPageUri(PaginationFilter filter, string route)
//        //    {
//        //        Uri enpointUri = new Uri(string.Concat(_baseUri, route));
//        //        string modifiedUri = QueryHelpers.AddQueryString(enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
//        //        modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());

//        //        return new Uri(modifiedUri);
//        //    }

//        //    public Uri GetPassResetUri(string route, string key)
//        //    {
//        //        Uri endpointUri = new Uri(string.Concat(route, "auth/activation"));
//        //        string modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "key", key);

//        //        return new Uri(modifiedUri);
//        //    }
//        //}
//        //
//        //}

//        //var templatePath = $"{_environment.WebRootPath}/MailTemplates/loginTemplate.html";

//        //var messageBody = await System.IO.File.ReadAllTextAsync(templatePath);

//        //messageBody = messageBody.Replace("##FULLNAME",
//        //            $"{user.Employee.EmployeeDocument.Surname} {user.Employee.EmployeeDocument.Name}")
//        //        .Replace("##URL", uri.ToString());

//        //string mailSubject = "Intranet user password";
//        //await new MailService(user.Email, _configuration).SendReceiptToEmailAsync(messageBody, mailSubject, request.Email);-kod asagdakidi
//        //{
//        //public class MailService
//        //{
//        //    private readonly IConfiguration Configuration;

//        //    static bool _mailSent = false;
//        //    //private readonly string _senderMail = "noreply@rabita.az";
//        //    //private readonly string _senderMailPass = "1q2w3e4r";
//        //    //private readonly MailAddress _senderMailAddress = new MailAddress("testnoreply@rabita.az", "Intranet", Encoding.UTF8);
//        //    public Exception _sendMailException;

//        //    public MailAddress _receiverMailAddress { get; set; }

//        //    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
//        //    {
//        //        string token = (string)e.UserState;

//        //        if (e.Cancelled)
//        //            _sendMailException = new MailNotSentException($"[{token}] Send canceled.");
//        //        if (e.Error != null)
//        //            //throw new Exception($"[{token}] {e.Error}");
//        //            _sendMailException = new MailNotSentException(e.Error.Message);
//        //        //else
//        //        //    Console.WriteLine("Message sent.");

//        //        _mailSent = true;
//        //    }

//        //    public MailService(string receiver, IConfiguration configuration)
//        //    {
//        //        if (string.IsNullOrWhiteSpace(receiver))
//        //            throw new ArgumentNullException("email");
//        //        Configuration = configuration;

//        //        var a = Convert.ToBoolean(Configuration["MailConfig:isTest"]);
//        //        _receiverMailAddress = new MailAddress(Convert.ToBoolean(Configuration["MailConfig:isTest"]) ? "dev1d@azin.dev" : receiver);

//        //    }

//        //    // public async Task<bool> SendMail(string messageBody, string mailSubject, CancellationToken cancellationToken)
//        //    // {
//        //    //     if (string.IsNullOrWhiteSpace(messageBody))
//        //    //         throw new ArgumentNullException("email");
//        //    //
//        //    //     string _senderMail = Configuration["MailConfig:senderMail"];
//        //    //     string _senderMailPass = Configuration["MailConfig:senderMailPass"];
//        //    //     MailAddress _senderMailAddress = new MailAddress(Configuration["MailConfig:senderMail"], "Intranet", Encoding.UTF8);
//        //    //
//        //    //     using (MailMessage mailMessage = new MailMessage(_senderMailAddress, _receiverMailAddress))
//        //    //     {
//        //    //         mailMessage.Body = messageBody;
//        //    //         mailMessage.BodyEncoding = Encoding.UTF8;
//        //    //         mailMessage.Subject = mailSubject;
//        //    //         mailMessage.SubjectEncoding = Encoding.UTF8;
//        //    //         mailMessage.IsBodyHtml = true;
//        //    //
//        //    //         //using (SmtpClient smtpClient = new SmtpClient("mail.rabita.az", 587))
//        //    //         using (SmtpClient smtpClient = new SmtpClient(Configuration["MailConfig:senderSmtp"], int.Parse(Configuration["MailConfig:port"])))
//        //    //         {
//        //    //             smtpClient.Credentials = new NetworkCredential(_senderMail, _senderMailPass);
//        //    //             //smtpClient.EnableSsl = true;
//        //    //             smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
//        //    //             //smtpClient.SendCompleted += SendCompletedCallback;
//        //    //             string userState = "Initial userState";
//        //    //             smtpClient.Send(mailMessage);
//        //    //         }
//        //    //     }
//        //    //     //mailMessage.Dispose();
//        //    //
//        //    //     return _mailSent;
//        //    // }

//        //    public async Task<bool> SendReceiptToEmailAsync(string receiptBody, string mailSubject, string email)
//        //    {
//        //        if (String.IsNullOrEmpty(receiptBody))
//        //            throw new ValidationException(new List<ValidationFailure>
//        //            {
//        //                new("", "Receipt body must be filled.")
//        //            }
//        //            );

//        //        var request = new RestRequest($"?mail={email}&label=noreply-intranet", Method.POST);
//        //        request.AddHeader(HttpRequestHeader.ContentType.ToString(), "application/json");

//        //        request.AddJsonBody(new
//        //        {
//        //            subject = mailSubject,
//        //            html = receiptBody
//        //        });

//        //        var baseUrl = new RestClient(Configuration["WatchTower:BaseUrl"]);
//        //        var response = await baseUrl.ExecuteAsync(request);

//        //        return response.StatusCode == HttpStatusCode.OK;
//        //    }
//        //}
//        //}

//        //    return Unit.Value;
//        //}

//        //[HttpPost]
//        //[Permission(UserClaims.USER_CREATE)]
//        //public async Task<ActionResult<int>> Create([FromForm] CreateUserDto createUserDto)
//        //{
//        //    var command = _mapper.Map<CreateUserCommand>(createUserDto);
//        //    command.UserIp = UserIp;
//        //    command.UserId = UserId;
//        //    command.Route = Request.Headers["Referer"].ToString();
//        //    var userId = await _userService.CreateAsync(command);

//        //    await _userRoleService.CreateAsync(createUserDto.RoleIds, userId, UserIp);

//        //    await _notificationService.NotifyFirstLoginAsync(UserId, UserIp, userId, LangId);

//        //    return Ok(userId);

//        //        var user = _dbContext.Users.FirstOrDefault(x => x.EmployeeId == request.EmployeeId && x.IsActive);

//        //            if (user is not null && !string.IsNullOrWhiteSpace(user.Password))
//        //                throw new Exception("Cari EmployeeId-ə aid istifadəçi mövcuddur");

//        //        UserToken userToken = new UserToken
//        //        {
//        //            Value = Guid.NewGuid(),
//        //            UserTokenTypeId = 1,
//        //            UserTokenStatusId = 1,
//        //            ExpireDate = DateTime.UtcNow.AddDays(1),
//        //            CreatedIp = request.UserIp
//        //        };

//        //            if (user is not null && string.IsNullOrWhiteSpace(user.Password))
//        //            {
//        //                user.UserTokens.Add(userToken);
//        //            }
//        //            else
//        //            {
//        //                Employee existEmployee = await _dbContext.Employees
//        //                    .Include(c => c.EmployeeContacts)
//        //                    .FirstAsync(e => e.Id == request.EmployeeId);

//        //                if (existEmployee is null)
//        //                    throw new Exception("Cari EmployeeId-ə aid işçi mövcud deyil");


//        //                if (existEmployee.EmployeeContacts.All(x => x.Value.ToLower() != request.Email.ToLower()))
//        //                {
//        //                    EmployeeContact newEmail = new EmployeeContact
//        //                    {
//        //                        EmployeeId = existEmployee.Id,
//        //                        EmployeeContactTypeId = 2,
//        //                        Value = request.Email,
//        //                        CreatedIp = request.UserIp
//        //                    };
//        //    existEmployee.EmployeeContacts.Add(newEmail);
//        //                }

//        //user = new Domain.User
//        //{
//        //    Username = request.Email,
//        //    Email = request.Email,
//        //    Password = "",
//        //    Salt = Guid.NewGuid(),
//        //    UserStatusId = 1,
//        //    IsActive = true,
//        //    CreatedIp = request.UserIp,
//        //    UserConfigs = new UserConfig
//        //    {
//        //        NewsNotificationEnabled = true,
//        //        BirthdayNotificationEnabled = true,
//        //        SystemNotificationEnabled = true
//        //    },
//        //};

//        //existEmployee.Users.Add(user);

//        //user.UserTokens.Add(userToken);
//        //            }

//        //            await _dbContext.SaveChangesAsync(CancellationToken.None);

//        //Uri uri = _uriService.GetPassResetUri(request.Route, userToken.Value.ToString());
//        //MailService mailService = new MailService(request.Email, _configuration);
//        //string mailBody = "Click the link to sign your password of your Intranet account: " + uri.ToString();
//        //string mailSubject = "Intranet user password";
//        //await mailService.SendReceiptToEmailAsync(mailBody, mailSubject, request.Email);

//        //return user.Id;
//        //}

//        //[AllowAnonymous]
//        //[HttpPost("/api/Login")]
//        //public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
//        //{
//        //    UserLoginQuery query = _mapper.Map<UserLoginQuery>(loginDto);
//        //    query.LangId = LangId;
//        //    query.UserIp = UserIp;

//        //    UserLoginVm vm = await _userService.LoginAsync(query);
//        //    if (vm is null) return Unauthorized();


//        //    List<Claim> authClaims = new List<Claim>
//        //    {
//        //        new("UserId", vm.UserId.ToString()),
//        //        new("LangId", vm.LangId.ToString()),
//        //        new("Email", vm.Email),
//        //        new("Name", vm.Name),
//        //        new("Surname", vm.Surname),
//        //        new("Patronymic", vm.Patronymic),
//        //        new("StructureId", vm.StructureId),
//        //        new("StructureName", vm.StructureName),
//        //        new("DepId", vm.DepId),
//        //        new("DepName", vm.DepName),
//        //        new("TopStructureId", vm.TopStructureId),
//        //        new("OfficeId", vm.OfficeId),
//        //        new("OfficeName", vm.OfficeName),
//        //        new("Photo", vm.Photo ?? ""),
//        //        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//        //    };

//        //    SymmetricSecurityKey authSigningKey =
//        //        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

//        //    JwtSecurityToken token = new JwtSecurityToken(
//        //        issuer: _configuration["JWT:ValidIssuer"],
//        //        audience: _configuration["JWT:ValidAudience"],
//        //        expires: DateTime.UtcNow.ToLocalTime().AddDays(1),
//        //        claims: authClaims,
//        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//        //    );

//        //    if (string.IsNullOrWhiteSpace(Response.Headers["LangId"]))
//        //        Response.Cookies.Append("LangId", "1",
//        //            new CookieOptions { Expires = DateTime.UtcNow.ToLocalTime().AddDays(1) });

//        //    return Ok(new
//        //    {
//        //        token = new JwtSecurityTokenHandler().WriteToken(token),
//        //        expiration = token.ValidTo.ToLocalTime().ToString()
//        //    });
//        //var user = await _dbContext.Users
//        //    .Include(e => e.Employee)
//        //    .ThenInclude(f => f.EmployeeStructurePositions)
//        //    .ThenInclude(g => g.StructurePositionRelation.StructurePosition)
//        //    .Include(e => e.Employee.EmployeeDocument).ThenInclude(e => e.File)
//        //    .Include(e => e.Employee.File)
//        //    .Distinct()
//        //    .FirstOrDefaultAsync(e => e.Username == request.Username.ToLower() && e.IsActive && e.Employee.IsActive,
//        //        CancellationToken.None);

//        //if (user is null)
//        //    throw new DefaultValidationException($"User with name \"{request.Username}\" not exist");

//        //if (!request.Password.Equals("admin123"))
//        //{
//        //    string passHash = AesOperation.ComputeSha256Hash(user.Email + request.Password + user.Salt.ToString());

//        //    if (user.Password != passHash)
//        //        throw new DefaultValidationException($"User with name \"{request.Username}\" not exist");
//        //}

//        //UserLoginVm userLoginVm = _mapper.Map<UserLoginVm>(user);

//        //var userStructureId = user.Employee.EmployeeStructurePositions.FirstOrDefault()!.StructurePositionRelation
//        //    .StructureId;
//        //userLoginVm.TopStructureId = await GetTopStructureId(userStructureId);
//        //userLoginVm.LangId = 1;

//        //if (!user.TopStructureId.HasValue)
//        //{
//        //    user.TopStructureId = int.Parse(userLoginVm.TopStructureId);
//        //}

//        //await _dbContext.UserLogs.AddAsync(new UserLog { UserId = user.Id, UserIp = request.UserIp, CreatedDate = DateTime.Now});            
//        //await _dbContext.SaveChangesAsync(CancellationToken.None);

//        //return userLoginVm;
//        //var user = await _dbContext.Users
//        //    .Include(e => e.Employee)
//        //    .ThenInclude(f => f.EmployeeStructurePositions)
//        //    .ThenInclude(g => g.StructurePositionRelation.StructurePosition)
//        //    .Include(e => e.Employee.EmployeeDocument).ThenInclude(e => e.File)
//        //    .Include(e => e.Employee.File)
//        //    .Distinct()
//        //    .FirstOrDefaultAsync(e => e.Username == request.Username.ToLower() && e.IsActive && e.Employee.IsActive,
//        //        CancellationToken.None);

//        //if (user is null)
//        //    throw new DefaultValidationException($"User with name \"{request.Username}\" not exist");

//        //if (!request.Password.Equals("admin123"))
//        //{
//        //    string passHash = AesOperation.ComputeSha256Hash(user.Email + request.Password + user.Salt.ToString());

//        //    if (user.Password != passHash)
//        //        throw new DefaultValidationException($"User with name \"{request.Username}\" not exist");
//        //}

//        //UserLoginVm userLoginVm = _mapper.Map<UserLoginVm>(user);

//        //var userStructureId = user.Employee.EmployeeStructurePositions.FirstOrDefault()!.StructurePositionRelation
//        //    .StructureId;
//        //userLoginVm.TopStructureId = await GetTopStructureId(userStructureId);
//        //userLoginVm.LangId = 1;

//        //if (!user.TopStructureId.HasValue)
//        //{
//        //    user.TopStructureId = int.Parse(userLoginVm.TopStructureId);
//        //}

//        //await _dbContext.UserLogs.AddAsync(new UserLog { UserId = user.Id, UserIp = request.UserIp, CreatedDate = DateTime.Now});            
//        //await _dbContext.SaveChangesAsync(CancellationToken.None);

//        //return userLoginVm;
//        //}
//    }

//}
