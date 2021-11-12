using ContasBancarias.Domain.Models;
using ContasBancarias.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contas> Contas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("ContasBancarias");

            builder.ApplyConfiguration(new ContasConfiguration());
            builder.ApplyConfiguration(new BancosConfiguration());

            builder.Entity<Bancos>()
               .HasData(new List<Bancos>(){
                   new Bancos(1, "001", "BANCO DO BRASIL"),
                   new Bancos(2, "070", "BRB"),
                   new Bancos(3, "104", "CAIXA ECONÔMICA FEDERAL"),
                   new Bancos(4, "429", "BANCO INTER"),
                   new Bancos(6, "237", "BRADESCO"),
                   new Bancos(7, "008", "SANTANDER"),
                   new Bancos(8, "756", "SICOOB"),
                   new Bancos(9, "048", "ITAU"),
                   new Bancos(10, "422", "SAFRA"),
                   new Bancos(11, "477", "CITIBANK")
               });
        }
    }
}