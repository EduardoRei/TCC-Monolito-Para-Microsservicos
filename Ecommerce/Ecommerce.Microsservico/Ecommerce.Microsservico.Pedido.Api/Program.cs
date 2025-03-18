using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using Ecommerce.Microsservico.Pedido.Api.Core.Service;
using Ecommerce.Microsservico.Pedido.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoPedidoService, ProdutoPedidoService>();

builder.Services.AddDbContext<PedidoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PedidoDbContext>();

    var retryCount = 5;
    while (retryCount > 0)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (Exception ex)
        {
            retryCount--;
            Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}. Tentando novamente...");
            Thread.Sleep(5000); 
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
