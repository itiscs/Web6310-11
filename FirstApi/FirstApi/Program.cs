using FirstApi;
using FirstApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options =>
                  {
                      options.RequireHttpsMetadata = false;
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          // ��������, ����� �� �������������� �������� ��� ��������� ������
                          ValidateIssuer = true,
                          // ������, �������������� ��������
                          ValidIssuer = AuthOptions.ISSUER,

                          // ����� �� �������������� ����������� ������
                          ValidateAudience = true,
                          // ��������� ����������� ������
                          ValidAudience = AuthOptions.AUDIENCE,
                          // ����� �� �������������� ����� �������������
                          ValidateLifetime = true,

                          // ��������� ����� ������������
                          IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                          // ��������� ����� ������������
                          ValidateIssuerSigningKey = true
                      };
                  });



builder.Services.AddDbContext<MyBaseContext>(opt =>
    opt.UseNpgsql("Host=localhost;Port=5433;Database=apibase25;Username=postgres;Password=1"));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
