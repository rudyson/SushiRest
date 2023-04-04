using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SushiRest.Api.Contexts;
using SushiRest.Api.Repositories;
using SushiRest.Api.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/*
#region JWT Configuration

builder.Services.Configure<JsonWebTokenOptions>(builder.Configuration.GetSection("JsonWebToken"));
var secretKey = builder.Configuration.GetSection("JsonWebToken:SecretKey").Value;
var issuer = builder.Configuration.GetSection("JsonWebToken:Issuer").Value;
var audience = builder.Configuration.GetSection("JsonWebToken:Audience").Value;
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            IssuerSigningKey = signingKey,
            ValidateIssuerSigningKey = true
        };
    });

#endregion
*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sushi Rest API",
        Version = "v1",
        Description = "An API to to interact with the restaurant",
        //TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Ruslan Diadiushkin",
            Email = "contact@xnrudyson.anonaddy.me",
            Url = new Uri("https://www.linkedin.com/in/rudyson"),
        },
        License = new OpenApiLicense
        {
            Name = "Sushi Rest API MIT License",
            Url = new Uri("https://github.com/rudyson/SushiRest/blob/master/LICENSE"),
        }
    });
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<SushiRestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<DatabaseContextSeeding>();

#region System.Text.Json => options

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.WriteIndented = true);

#endregion

#region Repositories

// Repository registration in builder
builder.Services.AddScoped<IProductRepository, ProductRepository>();

#endregion

#region Automapper profile

builder.Services.AddAutoMapper(
    typeof(Program).Assembly,
    typeof(AutomapperProfile).Assembly
);

#endregion

var app = builder.Build();
#region Seeding
SeedDatabase(app);
void SeedDatabase(IHost host)
{
    var scopedFactory = host.Services.GetService<IServiceScopeFactory>();
    if (scopedFactory == null) return;
    var scope = scopedFactory.CreateScope();
    var service = scope.ServiceProvider.GetService<DatabaseContextSeeding>();
    Task.Run(async () => await service!.Seed());
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
