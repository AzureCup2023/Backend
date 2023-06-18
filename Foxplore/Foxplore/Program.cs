using Foxplore;
using Foxplore.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddDbContext<PoIContext>(
//     o => o.UseSqlite("Data Source=Foxplore.db"));
builder.Services.AddSingleton<InMemoryDatabase>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//setup database
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<PoIContext>();
//     DbInitializer.Initialize(context);
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();