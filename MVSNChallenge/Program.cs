using Microsoft.EntityFrameworkCore;
using MVSNChallenge.Controller;
using MVSNChallenge.Models;
using System.Data.Common;
using System.Data;
using MVSNChallenge.Models.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var services = builder.Services;
builder.Services.AddDbContext<MvsnchallengeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

services.AddEndpointsApiExplorer();
services.AddHttpContextAccessor();
//
var app = builder.Build();
//app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "My Swagger";
});


app.Run();
