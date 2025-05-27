////using Amazon.S3;
////using FrameIt.Core;
////using FrameIt.Core.Repositories;
////using FrameIt.Core.Services;
////using FrameIt.Data;
////using FrameIt.Data.Repositories;
////using FrameIt.service;
////using Microsoft.AspNetCore.Authentication.JwtBearer;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;
//////using Microsoft.EntityFrameworkCore;
////using Microsoft.Extensions.Configuration;
////using Microsoft.IdentityModel.Tokens;
////using Microsoft.OpenApi.Models;
////using MySql.EntityFrameworkCore.Extensions;
////using System.Text;
////using System.Text.Json;
////using System.Text.Json.Serialization;

////// בשלב של קונפיגורציה של שירותי ה-Controllers

////var builder = WebApplication.CreateBuilder(args);
////builder.Configuration.AddEnvironmentVariables();
////builder.Services.AddControllers()
////    .AddJsonOptions(options =>
////    {
////        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
////    });
////// Add services to the container.

////builder.Services.AddControllers();
//////var configuration = builder.Configuration;
//////builder.Services.AddSingleton<IConfiguration>(configuration);
////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////builder.Services.AddScoped<IUserService, UserService>();
////builder.Services.AddScoped<IUserRepository, UserRepository>();
////builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
////builder.Services.AddScoped<IImageItemRepository, ImageItemRepository>();
////builder.Services.AddScoped<IImageService, ImageService>();
////builder.Services.AddScoped<ICollageRepository, CollageRepository>();
////builder.Services.AddScoped<ICollageService, CollageService>();
////builder.Services.AddScoped<UserService>();

//////builder.Services.AddControllers().AddJsonOptions(options =>
//////{
//////    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//////});

////var awsOptions = builder.Configuration.GetSection("AWS");
////builder.Services.AddSingleton<IAmazonS3>(sp =>
////    new AmazonS3Client(
////        awsOptions["AccessKey"],
////        awsOptions["SecretKey"],
////        new AmazonS3Config
////        {
////            RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(awsOptions["Region"])
////        }

////       ));

//////builder.Services.AddSingleton<IConfiguration, BaseConfiguration>();
//////builder.Services.AddDbContext<DataContext>();
////builder.Services.AddAutoMapper(typeof(MappingProfile));


////var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
////Console.WriteLine($"Connection string: {connectionString}");

////builder.Services.AddDbContext<DataContext>(options =>
////    options.UseMySQL(connectionString));
/////////////////////////////////////////////////=====gpt===//////////////////////////////////////////////
//////builder.Services.AddDbContext<DataContext>(options =>
//////    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
/////////////////////////////////////////////////////////////////////////////////////////////////



////builder.Services.AddAuthentication(options =>
////{
////    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
////    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
////})
////.AddJwtBearer(options =>
////{
////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuer = true,
////        ValidateAudience = true,
////        ValidateLifetime = true,
////        ValidateIssuerSigningKey = true, 
////        ValidIssuer = builder.Configuration["Jwt:Issuer"],
////        ValidAudience = builder.Configuration["Jwt:Audience"],
////        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
////        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"


////    };
////});


////builder.Services.AddSwaggerGen(options =>
////{
////    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
////    {
////        Scheme = "Bearer",
////        BearerFormat = "JWT",
////        In = ParameterLocation.Header,
////        Name = "Authorization",
////        Description = "Bearer Authentication with JWT Token",
////        Type = SecuritySchemeType.Http
////    });
////    options.AddSecurityRequirement(new OpenApiSecurityRequirement
////    {
////        {
////            new OpenApiSecurityScheme
////            {
////                Reference = new OpenApiReference
////                {
////                    Id = "Bearer",
////                    Type = ReferenceType.SecurityScheme
////                }
////            },
////            new List<string>()
////        }
////    });
////});



//////builder.Services.AddCors(options =>
//////{
//////    options.AddPolicy("AllowAll",
//////        policy =>
//////        {
//////            policy.AllowAnyOrigin()
//////                  .AllowAnyMethod()
//////                  .AllowAnyHeader();
//////        });
//////});
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowAll", builder =>
////    {
////        builder.AllowAnyOrigin()
////               .AllowAnyHeader()
////               .AllowAnyMethod();
////    });
////});



////var app = builder.Build();

////app.UseCors("AllowAll");

////app.UseHttpsRedirection();

////app.UseAuthentication();
////app.UseAuthorization();

////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.MapGet("/", () => "Server is running...");

////app.MapControllers();

////app.Run();
//using Amazon.S3;
//using FrameIt.Core;
//using FrameIt.Core.Repositories;
//using FrameIt.Core.Services;
//using FrameIt.Data;
//using FrameIt.Data.Repositories;
//using FrameIt.service;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using MySql.EntityFrameworkCore.Extensions;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//var builder = WebApplication.CreateBuilder(args);

//// הוספת Environment Variables
//builder.Configuration.AddEnvironmentVariables();

//// הגדרת Controllers עם JSON options
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    });

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// הרשמת Services
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.AddScoped<IImageItemRepository, ImageItemRepository>();
//builder.Services.AddScoped<IImageService, ImageService>();
//builder.Services.AddScoped<ICollageRepository, CollageRepository>();
//builder.Services.AddScoped<ICollageService, CollageService>();
//builder.Services.AddScoped<UserService>();
//builder.Services.AddAutoMapper(typeof(MappingProfile));

//// AWS S3 Configuration
//var awsOptions = builder.Configuration.GetSection("AWS");
//builder.Services.AddSingleton<IAmazonS3>(sp =>
//    new AmazonS3Client(
//        awsOptions["AccessKey"],
//        awsOptions["SecretKey"],
//        new AmazonS3Config
//        {
//            RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(awsOptions["Region"])
//        }
//    ));

//// Database Configuration
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Console.WriteLine($"Connection string: {connectionString}");
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySQL(connectionString));

//// JWT Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
//    };

//    // הוספת event handlers לטיפול טוב יותר בשגיאות JWT
//    options.Events = new JwtBearerEvents
//    {
//        OnChallenge = context =>
//        {
//            context.HandleResponse();
//            context.Response.StatusCode = 401;
//            context.Response.ContentType = "application/json";
//            return context.Response.WriteAsync(
//                "{\"message\": \"Unauthorized access. Please log in with valid credentials.\"}");
//        },
//        OnForbidden = context =>
//        {
//            context.Response.StatusCode = 403;
//            context.Response.ContentType = "application/json";
//            return context.Response.WriteAsync(
//                "{\"message\": \"Access denied. You do not have permission to perform this action.\"}");
//        }
//    };
//});

//// Swagger Configuration
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Id = "Bearer",
//                    Type = ReferenceType.SecurityScheme
//                }
//            },
//            new List<string>()
//        }
//    });
//});

//// CORS Configuration - תיקון חשוב!
//builder.Services.AddCors(options =>
//{
//    // Policy מאובטח עבור production
//    options.AddPolicy("AllowFrontend", corsPolicy =>
//    {
//        corsPolicy.WithOrigins(
//                "https://frameitreact.onrender.com", // הדומיין שלך
//                "http://localhost:3000",             // React development
//                "http://localhost:5173",             // Vite development
//                "http://localhost:4200"              // Angular development
//            )
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials()
//            .SetIsOriginAllowedToAllowWildcardSubdomains();
//    });

//    // Policy פתוח עבור development
//    options.AddPolicy("AllowAll", corsPolicy =>
//    {
//        corsPolicy.AllowAnyOrigin()
//                 .AllowAnyHeader()
//                 .AllowAnyMethod();
//    });
//});

//var app = builder.Build();

//// הגדרת הMiddleware Pipeline - סדר חשוב מאוד!

//// CORS צריך להיות ראשון לפני כל השאר
//app.UseCors(app.Environment.IsDevelopment() ? "AllowAll" : "AllowFrontend");

//// בדיקה אם בסביבת פיתוח
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// Authentication ו-Authorization אחרי CORS
//app.UseAuthentication();
//app.UseAuthorization();

//// Routes
//app.MapGet("/", () => "Server is running...");
//app.MapControllers();

//app.Run();











using Amazon.S3;
using FrameIt.Core;
using FrameIt.Core.Repositories;
using FrameIt.Core.Services;
using FrameIt.Data;
using FrameIt.Data.Repositories;
using FrameIt.service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySql.EntityFrameworkCore.Extensions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// הוספת Environment Variables
builder.Configuration.AddEnvironmentVariables();

// הגדרת Controllers עם JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// הרשמת Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IImageItemRepository, ImageItemRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICollageRepository, CollageRepository>();
builder.Services.AddScoped<ICollageService, CollageService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// AWS S3 Configuration
var awsOptions = builder.Configuration.GetSection("AWS");
builder.Services.AddSingleton<IAmazonS3>(sp =>
    new AmazonS3Client(
        awsOptions["AccessKey"],
        awsOptions["SecretKey"],
        new AmazonS3Config
        {
            RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(awsOptions["Region"])
        }
    ));

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection string: {connectionString}");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySQL(connectionString));

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
    };

    // הוספת event handlers לטיפול טוב יותר בשגיאות JWT
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(
                "{\"message\": \"Unauthorized access. Please log in with valid credentials.\"}");
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(
                "{\"message\": \"Access denied. You do not have permission to perform this action.\"}");
        }
    };
});

// Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

// CORS Configuration - תיקון חשוב!
builder.Services.AddCors(options =>
{
    // Policy מאובטח עבור production
    options.AddPolicy("AllowFrontend", corsPolicy =>
    {
        corsPolicy.WithOrigins(
                "https://frameitreact.onrender.com", // הדומיין שלך
                "http://localhost:3000",             // React development
                "http://localhost:5173",             // Vite development
                "http://localhost:4200"              // Angular development
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
    });

    // Policy פתוח עבור development
    options.AddPolicy("AllowAll", corsPolicy =>
    {
        corsPolicy.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod();
    });
});

var app = builder.Build();

// DEBUG: הדפס את כל ה-endpoints שנרשמו
Console.WriteLine("=== Registered Endpoints ===");
var endpointDataSource = app.Services.GetRequiredService<EndpointDataSource>();
foreach (var endpoint in endpointDataSource.Endpoints)
{
    if (endpoint is RouteEndpoint routeEndpoint)
    {
        Console.WriteLine($"Route: {routeEndpoint.RoutePattern.RawText} | Methods: {string.Join(", ", routeEndpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods ?? new[] { "N/A" })}");
    }
    else
    {
        Console.WriteLine($"Endpoint: {endpoint.DisplayName}");
    }
}
Console.WriteLine("=== End Endpoints ===");

// הגדרת הMiddleware Pipeline - סדר חשוב מאוד!

// CORS צריך להיות ראשון לפני כל השאר
app.UseCors(app.Environment.IsDevelopment() ? "AllowAll" : "AllowFrontend");

// הפעל Swagger גם ב-production עבור debugging
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FrameIt API V1");
    c.RoutePrefix = "swagger"; // זה יאפשר גישה ב-/swagger
});

app.UseHttpsRedirection();

// Authentication ו-Authorization אחרי CORS
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapGet("/", () => "Server is running...");
app.MapControllers();

app.Run();