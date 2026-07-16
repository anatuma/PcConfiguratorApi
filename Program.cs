using Microsoft.EntityFrameworkCore;
using PcConfiguratorApi.Contexts;
using PcConfiguratorApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        
builder.Services.AddScoped<IPCService, PCService>();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
       
app.MapControllers();
        
app.Run();
