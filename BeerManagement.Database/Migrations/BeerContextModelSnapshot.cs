﻿// <auto-generated />
using System;
using BeerManagement.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeerManagement.Database.Migrations
{
    [DbContext(typeof(BeerContext))]
    partial class BeerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("bm")
                .HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BeerManagement.Domain.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AlcoholLevel")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BreweryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers", "bm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ccb534da-6a31-44f3-9995-faa0301a8f31"),
                            AlcoholLevel = 6.6m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe Blonde",
                            Price = 2.2m
                        },
                        new
                        {
                            Id = new Guid("4341fe34-68b6-49f1-aed1-d3ff0dd1a830"),
                            AlcoholLevel = 0m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe Blonde 0.0",
                            Price = 2.1m
                        },
                        new
                        {
                            Id = new Guid("e762513e-eb38-4e16-a0e3-e0fb0203d89c"),
                            AlcoholLevel = 8.5m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe Prestige",
                            Price = 2.2m
                        },
                        new
                        {
                            Id = new Guid("be795fdb-dfd8-4b81-b85f-fa372599ad3b"),
                            AlcoholLevel = 5m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe Ruby",
                            Price = 2.5m
                        },
                        new
                        {
                            Id = new Guid("38f9d512-b892-4149-a28b-0fddef0e75f1"),
                            AlcoholLevel = 0m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe Ruby 0.0",
                            Price = 2.4m
                        },
                        new
                        {
                            Id = new Guid("4814c82c-df0d-4794-8815-a15acf72f79a"),
                            AlcoholLevel = 9m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe rituel",
                            Price = 3m
                        },
                        new
                        {
                            Id = new Guid("f387ad39-e17a-4bc6-bab0-a12236451943"),
                            AlcoholLevel = 8.5m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe tripple",
                            Price = 3m
                        },
                        new
                        {
                            Id = new Guid("ec8405d7-c55c-41cb-9bfd-7a28696c36d5"),
                            AlcoholLevel = 6.6m,
                            BreweryId = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe ambrée",
                            Price = 2.8m
                        });
                });

            modelBuilder.Entity("BeerManagement.Domain.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Breweries", "bm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                            Name = "Leffe"
                        });
                });

            modelBuilder.Entity("BeerManagement.Domain.Wholesaler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers", "bm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                            Name = "GeneDrinks"
                        });
                });

            modelBuilder.Entity("BeerManagement.Domain.WholesalerStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("WholesalerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("WholesalerStocks", "bm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f2084e5-99de-4759-9d86-a357e92c4252"),
                            BeerId = new Guid("ccb534da-6a31-44f3-9995-faa0301a8f31"),
                            Quantity = 20,
                            WholesalerId = new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092")
                        },
                        new
                        {
                            Id = new Guid("394e073a-6355-434a-aebe-694dda77488e"),
                            BeerId = new Guid("4341fe34-68b6-49f1-aed1-d3ff0dd1a830"),
                            Quantity = 20,
                            WholesalerId = new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092")
                        },
                        new
                        {
                            Id = new Guid("b2e4e9e3-b4b2-4cd1-8223-b348710390d7"),
                            BeerId = new Guid("e762513e-eb38-4e16-a0e3-e0fb0203d89c"),
                            Quantity = 20,
                            WholesalerId = new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092")
                        },
                        new
                        {
                            Id = new Guid("2e55da49-70a9-4343-a4b2-6d64a8e31722"),
                            BeerId = new Guid("be795fdb-dfd8-4b81-b85f-fa372599ad3b"),
                            Quantity = 20,
                            WholesalerId = new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092")
                        },
                        new
                        {
                            Id = new Guid("d6b746ac-5dc7-4a49-ade3-83cb4e90be9f"),
                            BeerId = new Guid("38f9d512-b892-4149-a28b-0fddef0e75f1"),
                            Quantity = 20,
                            WholesalerId = new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092")
                        });
                });

            modelBuilder.Entity("BeerManagement.Domain.Beer", b =>
                {
                    b.HasOne("BeerManagement.Domain.Brewery", null)
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerManagement.Domain.WholesalerStock", b =>
                {
                    b.HasOne("BeerManagement.Domain.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerManagement.Domain.Wholesaler", null)
                        .WithMany("WholesalerStocks")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");
                });

            modelBuilder.Entity("BeerManagement.Domain.Brewery", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("BeerManagement.Domain.Wholesaler", b =>
                {
                    b.Navigation("WholesalerStocks");
                });
#pragma warning restore 612, 618
        }
    }
}