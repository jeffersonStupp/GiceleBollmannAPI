﻿// <auto-generated />
using GiceleBollmannAPI.Database.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GiceleBollmannAPI.Migrations
{
    [DbContext(typeof(GBcontexto))]
    partial class GBcontextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GiceleBollmannAPI.Models.Pontuacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PONTUACAO");
                });

            modelBuilder.Entity("GiceleBollmannAPI.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("money");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("PRODUTOS", (string)null);
                });

            modelBuilder.Entity("GiceleBollmannAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("usuario");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = false,
                            Email = "usuario@email.com",
                            Nome = "usuario",
                            Senha = "usuario",
                            Telefone = "(00)00000-0000",
                            Tipo = "usuario",
                            UserName = "usuario"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = false,
                            Email = "jeffersonstupp@hotmail.com",
                            Nome = "Jefferson Stupp",
                            Senha = "0411vm",
                            Telefone = "(47)98811-9538",
                            Tipo = "administrador",
                            UserName = "stupp"
                        });
                });

            modelBuilder.Entity("GiceleBollmannAPI.Models.Pontuacao", b =>
                {
                    b.HasOne("GiceleBollmannAPI.Models.Produto", "Produto")
                        .WithMany("Pontuacoes")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiceleBollmannAPI.Models.Usuario", "Usuario")
                        .WithMany("Pontuacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GiceleBollmannAPI.Models.Produto", b =>
                {
                    b.Navigation("Pontuacoes");
                });

            modelBuilder.Entity("GiceleBollmannAPI.Models.Usuario", b =>
                {
                    b.Navigation("Pontuacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
