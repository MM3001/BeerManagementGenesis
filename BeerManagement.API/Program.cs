using BeerManagement.API.Mapping;
using BeerManagement.Business;
using BeerManagement.Database;
using BeerManagement.Database.Logic;
using BeerManagement.IBusiness;
using BeerManagement.IDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BeerContext>();
builder.Services.AddScoped<IBeerDL, BeerDL>();
builder.Services.AddScoped<IBeerBL, BeerBL>();
builder.Services.AddScoped<IBreweryDL, BreweryDL>();
builder.Services.AddScoped<IBreweryBL, BreweryBL>();
builder.Services.AddScoped<IWholesalerDL, WholesalerDL>();
builder.Services.AddScoped<IWholesalerBL, WholesalerBL>();
builder.Services.AddScoped<IWholesalerStockDL, WholesalerStockDL>();
builder.Services.AddScoped<IWholesalerStockBL, WholesalerStockBL>();

builder.Services.AddAutoMapper(typeof(DomainToDtoProfile), typeof(DtoToDomainProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
