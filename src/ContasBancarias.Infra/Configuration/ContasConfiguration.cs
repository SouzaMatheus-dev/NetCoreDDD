using ContasBancarias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Infra.Configuration
{
    public class BancosConfiguration : IEntityTypeConfiguration<Bancos>
    {
        public void Configure(EntityTypeBuilder<Bancos> builder)
        {
            builder.ToTable("Bancos");
        }
    }
}