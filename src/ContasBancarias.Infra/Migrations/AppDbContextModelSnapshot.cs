﻿// <auto-generated />
using ContasBancarias.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContasBancarias.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ContasBancarias")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContasBancarias.Domain.Models.Contas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfOuCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EhAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("NomeOuRazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroAgencia")
                        .HasColumnType("int");

                    b.Property<int>("NumeroConta")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
