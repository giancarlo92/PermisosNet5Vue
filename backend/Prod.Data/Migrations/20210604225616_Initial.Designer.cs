﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prod.Data;

namespace Prod.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210604225616_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prod.Entities.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidosEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPermiso")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPermisoId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TipoPermisoId");

                    b.ToTable("Permiso");
                });

            modelBuilder.Entity("Prod.Entities.TipoPermiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TipoPermiso");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "gzevallos",
                            CreatedOn = new DateTime(2021, 6, 4, 17, 56, 15, 807, DateTimeKind.Local).AddTicks(965),
                            Descripcion = "Enfermedad"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "gzevallos",
                            CreatedOn = new DateTime(2021, 6, 4, 17, 56, 15, 807, DateTimeKind.Local).AddTicks(1514),
                            Descripcion = "Diligencias"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "gzevallos",
                            CreatedOn = new DateTime(2021, 6, 4, 17, 56, 15, 807, DateTimeKind.Local).AddTicks(1517),
                            Descripcion = "Otros"
                        });
                });

            modelBuilder.Entity("Prod.Entities.Permiso", b =>
                {
                    b.HasOne("Prod.Entities.TipoPermiso", "TipoPermiso")
                        .WithMany()
                        .HasForeignKey("TipoPermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPermiso");
                });
#pragma warning restore 612, 618
        }
    }
}
