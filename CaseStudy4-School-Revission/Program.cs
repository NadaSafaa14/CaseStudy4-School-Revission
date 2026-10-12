using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.Repos.Implementations;
using CaseStudy4_School_Revission.Repos.Interfaces;
using CaseStudy4_School_Revission.UoW.Implementation;
using CaseStudy4_School_Revission.UoW.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

builder.Services.AddScoped<IStudentRepo, StudentRepo>();

builder.Services.AddScoped<ICourseRepo, CourseRepo>();

builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();

builder.Services.AddScoped<IReportRepo, ReportRepo>();

builder.Services.AddScoped<IAuthRepo, AuthRepo>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(opt => 
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])
            ),
    };
});


//////
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.


app.Use(async (context, next) => 
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An unexpected error occurred.");

        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = 500,
                Message = "An unexpected error occurred."
            });
        }
    }
});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"[Request] Method: {context.Request.Method}, Path: {context.Request.Path}");

//    await next(); 

//    Console.WriteLine($"[Response] Status Code: {context.Response.StatusCode}");
//});

// Request Logging Middleware
app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;

    await next();

    var duration = DateTime.UtcNow - startTime;

    app.Logger.LogInformation
    (
        "Request: {Method} {Path} | Status Code: {StatusCode} | Duration: {Duration} ms",
        context.Request.Method,
        context.Request.Path,
        context.Response.StatusCode,
        duration.TotalMilliseconds
    );
});




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
