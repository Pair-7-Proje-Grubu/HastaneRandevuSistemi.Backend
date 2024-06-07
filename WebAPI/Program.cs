using Application;
using Core;
using Core.Utilities.Encryption;
using Core.Utilities.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddCoreServices(tokenOptions);


//string? securityKey = builder.Configuration.GetSection("TokenOptions").GetValue<string>("SecurityKey");


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
