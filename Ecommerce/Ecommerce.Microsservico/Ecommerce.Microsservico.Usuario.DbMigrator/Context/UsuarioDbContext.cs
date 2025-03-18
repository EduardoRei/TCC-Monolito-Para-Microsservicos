using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using UsuarioEntity = Ecommerce.Commons.Entities.Usuario;


namespace Ecommerce.Microsservico.Usuario.DbMigrator.Context
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity { Id = 1, Nome = "João Silva", Email = "joao.silva@example.com", Endereco = "Rua A, 123", CPF = "12345678901", Senha = "senha123", DataNascimento = new DateTime(1990, 1, 1), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 2, Nome = "Maria Souza", Email = "maria.souza@example.com", Endereco = "Rua B, 456", CPF = "23456789012", Senha = "senha123", DataNascimento = new DateTime(1992, 2, 2), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 3, Nome = "Carlos Pereira", Email = "carlos.pereira@example.com", Endereco = "Rua C, 789", CPF = "34567890123", Senha = "senha123", DataNascimento = new DateTime(1985, 3, 3), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 4, Nome = "Ana Costa", Email = "ana.costa@example.com", Endereco = "Rua D, 101", CPF = "45678901234", Senha = "senha123", DataNascimento = new DateTime(1988, 4, 4), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 5, Nome = "Pedro Almeida", Email = "pedro.almeida@example.com", Endereco = "Rua E, 202", CPF = "56789012345", Senha = "senha123", DataNascimento = new DateTime(1995, 5, 5), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 6, Nome = "Juliana Santos", Email = "juliana.santos@example.com", Endereco = "Rua F, 303", CPF = "67890123456", Senha = "senha123", DataNascimento = new DateTime(1993, 6, 6), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 7, Nome = "Rafael Oliveira", Email = "rafael.oliveira@example.com", Endereco = "Rua G, 404", CPF = "78901234567", Senha = "senha123", DataNascimento = new DateTime(1987, 7, 7), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 8, Nome = "Fernanda Lima", Email = "fernanda.lima@example.com", Endereco = "Rua H, 505", CPF = "89012345678", Senha = "senha123", DataNascimento = new DateTime(1991, 8, 8), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 9, Nome = "Lucas Rocha", Email = "lucas.rocha@example.com", Endereco = "Rua I, 606", CPF = "90123456789", Senha = "senha123", DataNascimento = new DateTime(1994, 9, 9), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 10, Nome = "Mariana Ribeiro", Email = "mariana.ribeiro@example.com", Endereco = "Rua J, 707", CPF = "01234567890", Senha = "senha123", DataNascimento = new DateTime(1989, 10, 10), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 11, Nome = "Bruno Fernandes", Email = "bruno.fernandes@example.com", Endereco = "Rua K, 808", CPF = "11234567890", Senha = "senha123", DataNascimento = new DateTime(1996, 11, 11), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 12, Nome = "Patricia Gomes", Email = "patricia.gomes@example.com", Endereco = "Rua L, 909", CPF = "12234567890", Senha = "senha123", DataNascimento = new DateTime(1997, 12, 12), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 13, Nome = "Rodrigo Martins", Email = "rodrigo.martins@example.com", Endereco = "Rua M, 1010", CPF = "13234567890", Senha = "senha123", DataNascimento = new DateTime(1986, 1, 13), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 14, Nome = "Aline Ferreira", Email = "aline.ferreira@example.com", Endereco = "Rua N, 1111", CPF = "14234567890", Senha = "senha123", DataNascimento = new DateTime(1998, 2, 14), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 15, Nome = "Thiago Barbosa", Email = "thiago.barbosa@example.com", Endereco = "Rua O, 1212", CPF = "15234567890", Senha = "senha123", DataNascimento = new DateTime(1990, 3, 15), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 16, Nome = "Camila Araujo", Email = "camila.araujo@example.com", Endereco = "Rua P, 1313", CPF = "16234567890", Senha = "senha123", DataNascimento = new DateTime(1992, 4, 16), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 17, Nome = "Felipe Mendes", Email = "felipe.mendes@example.com", Endereco = "Rua Q, 1414", CPF = "17234567890", Senha = "senha123", DataNascimento = new DateTime(1985, 5, 17), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 18, Nome = "Renata Carvalho", Email = "renata.carvalho@example.com", Endereco = "Rua R, 1515", CPF = "18234567890", Senha = "senha123", DataNascimento = new DateTime(1988, 6, 18), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 19, Nome = "Gustavo Lima", Email = "gustavo.lima@example.com", Endereco = "Rua S, 1616", CPF = "19234567890", Senha = "senha123", DataNascimento = new DateTime(1995, 7, 19), DataCriacaoUsuario = DateTime.Now },
                new UsuarioEntity { Id = 20, Nome = "Isabela Souza", Email = "isabela.souza@example.com", Endereco = "Rua T, 1717", CPF = "20234567890", Senha = "senha123", DataNascimento = new DateTime(1993, 8, 20), DataCriacaoUsuario = DateTime.Now }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
