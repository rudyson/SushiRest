using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SushiRest.Api.Contexts;
using SushiRest.Api.Entities;
using SushiRest.Api.Entities.Identity;
using SushiRest.Api.Repositories.Implementations;
using SushiRest.Api.Repositories.Services;
using SushiRest.Api.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
            Url = new Uri("https://www.linkedin.com/in/rudyson")
        },
        License = new OpenApiLicense
        {
            Name = "Sushi Rest API MIT License",
            Url = new Uri("https://github.com/rudyson/SushiRest/blob/master/LICENSE")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        In = ParameterLocation.Header, 
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { 
            new OpenApiSecurityScheme 
            { 
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" 
                } 
            },
            Array.Empty<string>()
        } 
    });
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

#region Database context service configuration

builder.Services.AddDbContext<SushiRestDbContext>(options =>
{
    var dbAddress = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "SushiRest";
    var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "admin";
    var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "admin";
    
    var connectionString = $"Server=postgresql;" +
                           $"Database={dbAddress};" +
                           $"Port=5432;" +
                           $"User Id={dbUser};" +
                           $"Password={dbPassword};";
    
    options.UseNpgsql(connectionString);
    // builder.Configuration.GetConnectionString("Default")
});

#endregion

#region AspNet Identity

builder.Services.AddIdentity<ApplicationUser,ApplicationRole>()
    .AddEntityFrameworkStores<SushiRestDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    
    options.User.RequireUniqueEmail = true;

});

#endregion

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
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true
        };
    });

builder.Services.AddScoped<IUserService, UserService>();

#endregion

// Context seeding
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
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

#endregion

#region Automapper profile

builder.Services.AddAutoMapper(
    typeof(Program).Assembly,
    typeof(AutomapperProfile).Assembly
);

#endregion

#region CORS policies

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowAll", p =>
        {
            p.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

#endregion

var app = builder.Build();

// CORS
app.UseCors("AllowAll");

#region EF Migrations

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SushiRestDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

#endregion
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

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
