using bankito.Repositories;
using bankito.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>(); 
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>(); 
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardService, CardService>(); 
builder.Services.AddScoped<IStatusCardRepository, StatusCardRepository>();
builder.Services.AddScoped<IStatusCardService, StatusCardService>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>(); 
builder.Services.AddScoped<IManualBanRepository, ManualBanRepository>();
builder.Services.AddScoped<IManualBanService, ManualBanService>(); 
builder.Services.AddScoped<IBanRepository, BanRepository>();
builder.Services.AddScoped<IBanService, BanService>(); 
builder.Services.AddScoped<IBankTransferRepository, BankTransferRepository>();
builder.Services.AddScoped<IBankTransferService, BankTransferService>(); 
builder.Services.AddScoped<IBankTransferStatusRepository, BankTransferStatusRepository>();
builder.Services.AddScoped<IBankTransferStatusService, BankTransferStatusService>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IBillService, BillService>(); 
builder.Services.AddScoped<IBillStatusRepository, BillStatusRepository>();
builder.Services.AddScoped<IBillStatusService, BillStatusService>(); 
builder.Services.AddScoped<IBillTypeRepository, BillTypeRepository>();
builder.Services.AddScoped<IBillTypeService, BillTypeService>(); 
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>(); 


builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5001; // Puerto HTTPS definido en launchSettings.json
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
