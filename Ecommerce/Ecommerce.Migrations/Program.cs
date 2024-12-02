using Ecommerce.Migrations.Context;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {

        // Conectar ao banco de dados usando a string de conexão diretamente
        var options = new DbContextOptionsBuilder<EcommerceDbContext>()
            .UseSqlServer("Server=localhost,1433;Database=ECommerceDB;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True;")
            .Options;

        using var dbContext = new EcommerceDbContext(options);

        // Aplica as migrations pendentes
        await dbContext.Database.MigrateAsync();

        Console.WriteLine("Banco de dados e migrations aplicadas com sucesso.");

    }
}
