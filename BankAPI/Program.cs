using BankAPI.Adaptes;
using BankAPI.BussinessLogic;
using BankAPI.Config;
using BankAPI.DbFactory;
using BankAPI.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConnectionConfig, ConnectionConfig>();
builder.Services.AddScoped<IBanksCardsDataBaseFactory, BanksCardsDataBaseFactory>();
builder.Services.AddSingleton<IStringEncryptor, StringEncryptor>();
builder.Services.AddSingleton<ICardGenerator, CardGenerator>();
builder.Services.AddScoped<IRequestToDataBaseAdapter, RequestToDataBaseAdapter>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();
builder.Services.AddScoped<ITransactionValidator, TransactionValidator>();

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
