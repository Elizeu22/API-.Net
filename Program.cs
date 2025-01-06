using Microsoft.EntityFrameworkCore;
using CadastroVeiculo.DB;
using CadastroVeiculo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("AberturaChamadoConnection");

builder.Services.AddDbContext<AberturaChamadoContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["AberturaChamadoConnection"]));


builder.Services.AddScoped<IChamadoService, ChamadosService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();

});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
