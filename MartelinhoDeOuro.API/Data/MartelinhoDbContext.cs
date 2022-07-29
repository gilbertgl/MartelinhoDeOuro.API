using MartelinhoDeOuro.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MartelinhoDeOuro.API.Data
{
    public class MartelinhoDbContext : DbContext
    {
        public MartelinhoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
