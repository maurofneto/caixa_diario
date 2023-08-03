using CashFlowTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTracker.Infrastructure.SqLite.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Defina um DbSet para cada entidade que deseja mapear no banco de dados
        public DbSet<Lancamento> Lancamentos { get; set; }
        // Outros DbSets para outras entidades, se houver

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais para mapear as entidades para as tabelas
            // Caso haja alguma configuração específica para alguma entidade, adicione aqui
        }
    }
}
