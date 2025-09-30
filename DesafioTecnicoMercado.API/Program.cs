using DesafioTecnicoMercado.Domain.Interfaces.Repositories;
using DesafioTecnicoMercado.Domain.Interfaces.Services;
using DesafioTecnicoMercado.Domain.Services;
using DesafioTecnicoMercado.Domain.Validations;  
using DesafioTecnicoMercado.Infra.Contexts;
using DesafioTecnicoMercado.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{    
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext"));
});


builder.Services.AddScoped<IProdutoService, ProdutoService>();


builder.Services.AddScoped<ProdutoValidator>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();