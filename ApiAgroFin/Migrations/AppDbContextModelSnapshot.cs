﻿// <auto-generated />
using System;
using ApiAgroFin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiAgroFin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiAgroFin.Models.Endereco", b =>
                {
                    b.Property<int>("Endereco_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Endereco_Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Endereco_Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Endereco_Numero")
                        .HasColumnType("int");

                    b.Property<int?>("Pessoa_Id")
                        .HasColumnType("int");

                    b.HasKey("Endereco_Id");

                    b.HasIndex("Pessoa_Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ApiAgroFin.Models.Pessoa", b =>
                {
                    b.Property<int>("Pessoa_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pessoa_Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pessoa_Numero_Identificador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pessoa_Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ApiAgroFin.Models.Endereco", b =>
                {
                    b.HasOne("ApiAgroFin.Models.Pessoa", "pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("Pessoa_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("ApiAgroFin.Models.Pessoa", b =>
                {
                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
