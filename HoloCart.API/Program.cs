using HoloCart.Core;
using HoloCart.Core.Middleware;
using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure;
using HoloCart.Infrastructure.Context;
using HoloCart.Infrastructure.Seeder;
using HoloCart.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});
builder.Services.AddInfrasractureDebendancies()
    .AddCoreDebendancies()
    .AddServiceDebendancies()
    .AddServiceRegistration(builder.Configuration);
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();




#region AllowCORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

#endregion
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseCors(CORS);

app.UseSwaggerUI(o => o.SwaggerEndpoint("/openapi/v1.json", "Swagger Demo"));
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
