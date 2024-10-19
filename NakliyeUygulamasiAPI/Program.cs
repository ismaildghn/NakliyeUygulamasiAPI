using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<NakliyeUygulamasiAPIDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));




var app = builder.Build();
app.MapControllers();
app.Run();