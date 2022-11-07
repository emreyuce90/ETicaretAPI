using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Enums;
using ETicaretAPI.Infrastructure.Services.Storages.Azure;
using ETicaretAPI.Infrastructure.Services.Storages.Local;
using ETicaretAPI.Application.ServiceRegistration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplicationService();
builder.Services.AddPersistentService();
builder.Services.AddInfraStructureService();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy => policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers().AddFluentValidation(configuration =>configuration.RegisterValidatorsFromAssemblyContaining<ProductAddValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options => options.TokenValidationParameters = new()
    {
        ValidateAudience = true, //Clientý temsil eder //Token ý tüketen kaynaðý validate et
        ValidateIssuer = true, //Saðlayýcý temsil eder //Token ý üreten kaynaðý validate eder
        ValidateLifetime = true,//Token ýn yaþam süresini validate eder
        ValidateIssuerSigningKey = true, //token ýn gizli keyini validate eder

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
    }); ;
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
