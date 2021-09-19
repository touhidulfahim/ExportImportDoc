﻿// <auto-generated />
using ExportImportApp.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExportImportApp.Migrations
{
    [DbContext(typeof(ExportImportDbContext))]
    [Migration("20210919063249_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExportImportApp.Models.CountryModel", b =>
                {
                    b.Property<long>("SysId")
                        .HasColumnType("bigint");

                    b.Property<string>("CountryNameBn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyBn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageBn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SysId");

                    b.ToTable("tb_Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
