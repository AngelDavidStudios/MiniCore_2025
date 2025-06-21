using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Comision.API.Models;
using Comision.API.Repository;
using Comision.API.Repository.Interfaces;
using Comision.API.Services;
using Comision.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors();

//Services AWS
var awsOptions = builder.Configuration.GetAWSOptions();
awsOptions.Profile = "AdminAccess";
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

// Repositories
builder.Services.AddScoped<IRepository<Vendedor>, VendedorRepository>();
builder.Services.AddScoped<IRepository<Regla>, RulerRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

// Services
builder.Services.AddScoped<IComisionService, ComisionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(static builder => 
    builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
app.UseAuthorization();
app.MapControllers();
app.Run();