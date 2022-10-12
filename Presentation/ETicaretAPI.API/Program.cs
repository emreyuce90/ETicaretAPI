using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Enums;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddPersistentService();
builder.Services.AddInfraStructureService();
builder.Services.AddStorage(StorageType.Azure);
builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy => policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers().AddFluentValidation(configuration =>configuration.RegisterValidatorsFromAssemblyContaining<ProductAddValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
