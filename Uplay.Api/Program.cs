using FluentValidation.AspNetCore;
using Uplay.Api.Attributes;
using Uplay.Application;
using Uplay.Application.Extensions;
using Uplay.Application.Helpers;
using Uplay.Persistence;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
Accessor.AppConfiguration = configuration;


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
}).AddFluentValidation(x => x.AutomaticValidationEnabled = false);


builder.Services.AddApplication(configuration);
builder.Services.AddPersistence(configuration);
builder.Services.InstallServicesInAssembly(configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowAnyOrigin();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseStaticFiles();



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();