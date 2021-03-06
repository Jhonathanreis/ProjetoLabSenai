﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiDB.Data;

namespace WebApiDB.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20200316204601_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("WebApiDB.Domain.Acesso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DtEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DtSaida")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SalaId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.HasIndex("UserId");

                    b.ToTable("Acesso");
                });

            modelBuilder.Entity("WebApiDB.Domain.Sala", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacidade")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoSala")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalComputadores")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnidInstitucional")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("WebApiDB.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CellPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodeRFID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApiDB.Domain.Acesso", b =>
                {
                    b.HasOne("WebApiDB.Domain.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId");

                    b.HasOne("WebApiDB.Domain.User", "User")
                        .WithMany("Acessos")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
