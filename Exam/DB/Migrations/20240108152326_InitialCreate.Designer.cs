﻿// <auto-generated />
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240108152326_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<string>("Damage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 15,
                            AttackModifier = 4,
                            AttackPerRound = 1,
                            Damage = "1d6",
                            DamageModifier = 2,
                            HitPoints = 7,
                            Name = "Goblin"
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 15,
                            AttackModifier = 4,
                            AttackPerRound = 1,
                            Damage = "1d6",
                            DamageModifier = 2,
                            HitPoints = 22,
                            Name = "Gnoll"
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 20,
                            AttackModifier = 9,
                            AttackPerRound = 3,
                            Damage = "1d8",
                            DamageModifier = 3,
                            HitPoints = 97,
                            Name = "Hobgoblin warlord"
                        },
                        new
                        {
                            Id = 4,
                            ArmorClass = 16,
                            AttackModifier = 4,
                            AttackPerRound = 1,
                            Damage = "2d8",
                            DamageModifier = 2,
                            HitPoints = 27,
                            Name = "Bugbear"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
