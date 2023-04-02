using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sushirestapi.Contexts;
using sushirestapi.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SushiRestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<DatabaseContextSeeding>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
