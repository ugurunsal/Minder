using Minder.Interface;
using Minder.Model;
using Minder.Repository;
using Minder.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MinderDBContext>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IDiscoverySettingRepository,DiscoverySettingRepository>();
builder.Services.AddScoped<IDiscoverySettingService,DiscoverySettingService>();
builder.Services.AddScoped<ILifeStyleRepository,LifeStyleRepository>();
builder.Services.AddScoped<ILifeStyleService,LifeStyleService>();
builder.Services.AddScoped<IPassionRepository,PassionRepository>();
builder.Services.AddScoped<IPassionService,PassionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
