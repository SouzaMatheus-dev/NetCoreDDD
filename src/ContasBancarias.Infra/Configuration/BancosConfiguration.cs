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
    public class ContasConfiguration : IEntityTypeConfiguration<Contas>
    {
        public void Configure(EntityTypeBuilder<Contas> builder)
        {
            builder.ToTable("Contas");
        }
    }
}