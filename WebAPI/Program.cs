using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.IoC;
using Microsoft.IdentityModel.Tokens;
using Core.DependencyResolvers;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// day 14 start
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = Core.Utilities.Security.Encryption.SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

builder.Services.AddDependencyResolvers(new ICoreModule[]{
    new CoreModule()
});

ServiceTool.Create(builder.Services);// day 14 end

////Autofac implemented to the IoC
//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();
//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();
//builder.Services.AddSingleton<IColorService, ColorManager>();
//builder.Services.AddSingleton<IColorDal, EfColorDal>();
//builder.Services.AddSingleton<IRentalService, RentalManager>();
//builder.Services.AddSingleton<IRentalDal, EfRentalDal>();

// IOC Container Autofac yapılandırması
builder.Host
       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacBusinessModule());
       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
