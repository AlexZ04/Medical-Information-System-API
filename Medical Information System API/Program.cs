using Microsoft.EntityFrameworkCore;
using Medical_Information_System_API.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Medical_Information_System_API.Classes;
using System.Text.Json.Serialization;
using System.Reflection;
using Medical_Information_System_API.Models;
using Quartz;
using Medical_Information_System_API.BackgroundProcesses;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // убираем встроенную валидацию моделей в запросах
    //options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { 
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },

                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    var pathXml = Path.Combine(AppContext.BaseDirectory, "api.xml");
    options.IncludeXmlComments(pathXml);
});

var db = new DatabaseManager();
db.CreateDatabase("mis_db");

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddQuartz(options =>
{
    var jobKey = new JobKey(nameof(ProccessClearBlacklistDb));

    options
        .AddJob<ProccessClearBlacklistDb>(jobKey)
        .AddTrigger(
            trigger => trigger.ForJob(jobKey).WithSimpleSchedule(
                schedule => schedule.WithIntervalInHours(24).RepeatForever())
            );

});

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var serviceScope = app.Services.CreateScope();
var context = serviceScope.ServiceProvider.GetService<DataContext>();
context?.Database.Migrate();

List<string> dependentTables = new List<string>() { "diagnose", "comment", "consultation", "inspection" };

if (builder.Configuration["EnterSpecialities"] == "1" && context != null)
{
    foreach (var table in dependentTables)
    {
        context.Database.ExecuteSqlRaw($"DELETE FROM {table}");
    }
    
    context.Database.ExecuteSqlRaw("DELETE FROM speciality");

    context.SpecialitiesList.AddRange(db.GetSpecList());

    await context.SaveChangesAsync();
}

if (builder.Configuration["EnterIcdData"] == "1" && context != null)
{
    foreach (var table in dependentTables)
    {
        context.Database.ExecuteSqlRaw($"DELETE FROM {table}");
    }

    context.Database.ExecuteSqlRaw("DELETE FROM icd10");

    context.Icd10.AddRange(new Icd10Manager().GetListIcd10());
    await context.SaveChangesAsync();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
