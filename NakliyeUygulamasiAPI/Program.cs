using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();

builder.Services.AddControllers();






var app = builder.Build();
app.MapControllers();
app.Run();