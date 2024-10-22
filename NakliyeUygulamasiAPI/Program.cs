using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Services;
using NakliyeUygulamasi.Infrastructure;
using NakliyeUygulamasi.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();






var app = builder.Build();


app.MapControllers();
app.Run();