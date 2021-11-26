﻿// <auto-generated />
using System;
using DGuard.Aplicacao.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DGuard.Aplicacao.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211126112835_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DGuard.Aplicacao.API.Models.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("IPPort")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Server");
                });

            modelBuilder.Entity("DGuard.Aplicacao.API.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("DGuard.Aplicacao.API.Models.Video", b =>
                {
                    b.HasOne("DGuard.Aplicacao.API.Models.Server", "Server")
                        .WithMany("Videos")
                        .HasForeignKey("ServerId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
