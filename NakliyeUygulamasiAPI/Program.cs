using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application;
using NakliyeUygulamasi.Application.Services;
using NakliyeUygulamasi.Infrastructure;
using NakliyeUygulamasi.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();






var app = builder.Build();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();