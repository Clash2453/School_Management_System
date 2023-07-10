using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Services;
using SchoolManagementSystem.Services.DataManipulation;
using SchoolManagementSystem.Services.DataOrganization;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authorization header using bearer token",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();

});
builder.Services.AddDbContext<SchoolDbContext>(options => 
    options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SchoolDb"))));
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin",
        options => options.WithOrigins("http://localhost:5173",
                "https://localhost:5173", "http://localhost:5173/login")
            .AllowCredentials()
        .AllowAnyMethod()
            .AllowAnyHeader()
    );
});
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(x=> x.Cookie.Name = "token")
    .AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("Authentication:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["token"];
                return Task.CompletedTask;
            }
        };
    }
    );
//data manipulation services
builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IGradingService, GradingService>();
builder.Services.AddScoped<IAbsenceService, AbsenceService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

//data organization services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAdminDataBundler, AdminDataBundler>();
builder.Services.AddScoped<ITeacherDataBundler, TeacherDataBundler>();
builder.Services.AddScoped<IStudentDataBundler, StudentDataBundler>();
builder.Services.AddScoped<IGpiService, GpiService>();
builder.Services.AddScoped<IGradeDataBundler, GradeDataBundler>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipelines
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();