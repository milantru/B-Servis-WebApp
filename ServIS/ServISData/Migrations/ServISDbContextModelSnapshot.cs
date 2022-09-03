﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServISData;

#nullable disable

namespace ServISData.Migrations
{
    [DbContext(typeof(ServISDbContext))]
    partial class ServISDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExcavatorPropertyTypeExcavatorType", b =>
                {
                    b.Property<int>("ExcavatorTypesWithThisPropertyId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyTypesId")
                        .HasColumnType("int");

                    b.HasKey("ExcavatorTypesWithThisPropertyId", "PropertyTypesId");

                    b.HasIndex("PropertyTypesId");

                    b.ToTable("ExcavatorPropertyTypeExcavatorType", (string)null);
                });

            modelBuilder.Entity("ExcavatorSparePart", b =>
                {
                    b.Property<int>("ExcavatorsId")
                        .HasColumnType("int");

                    b.Property<int>("SparePartsId")
                        .HasColumnType("int");

                    b.HasKey("ExcavatorsId", "SparePartsId");

                    b.HasIndex("SparePartsId");

                    b.ToTable("ExcavatorSparePart", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AcquiredExcavator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExcavatorId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LastInspection")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorId");

                    b.HasIndex("UserId");

                    b.ToTable("AcquiredExcavators", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ExcavatorCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExcavatorCategoryId");

                    b.ToTable("AdditionalEquipments", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipmentBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("AdditionalEquipmentBrands", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipmentCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("AdditionalEquipmentCategories", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipmentPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdditionalEquipmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTitle")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalEquipmentId");

                    b.ToTable("AdditionalEquipmentPhotos", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AuctionBid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuctionOfferId")
                        .HasColumnType("int");

                    b.Property<decimal>("Bid")
                        .HasColumnType("decimal(11,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionOfferId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionBids", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.AuctionOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ExcavatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OfferEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("StartingBid")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorId");

                    b.ToTable("AuctionOffers", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.Excavator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsForAuctionOnly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Excavators", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ExcavatorBrands", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("ExcavatorCategories", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExcavatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTitle")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorId");

                    b.ToTable("ExcavatorPhotos", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExcavatorId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("ExcavatorProperties", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorPropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("InputType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ExcavatorPropertyTypes", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExcavatorTypes", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.MainOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ExcavatorTypeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorTypeId");

                    b.ToTable("MainOffers", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CatalogNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("SpareParts", (string)null);
                });

            modelBuilder.Entity("ServISData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Residence")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ExcavatorPropertyTypeExcavatorType", b =>
                {
                    b.HasOne("ServISData.Models.ExcavatorType", null)
                        .WithMany()
                        .HasForeignKey("ExcavatorTypesWithThisPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.ExcavatorPropertyType", null)
                        .WithMany()
                        .HasForeignKey("PropertyTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExcavatorSparePart", b =>
                {
                    b.HasOne("ServISData.Models.Excavator", null)
                        .WithMany()
                        .HasForeignKey("ExcavatorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.SparePart", null)
                        .WithMany()
                        .HasForeignKey("SparePartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServISData.Models.AcquiredExcavator", b =>
                {
                    b.HasOne("ServISData.Models.Excavator", "Excavator")
                        .WithMany()
                        .HasForeignKey("ExcavatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excavator");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipment", b =>
                {
                    b.HasOne("ServISData.Models.AdditionalEquipmentBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.AdditionalEquipmentCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.ExcavatorCategory", "ExcavatorCategory")
                        .WithMany()
                        .HasForeignKey("ExcavatorCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("ExcavatorCategory");
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipmentPhoto", b =>
                {
                    b.HasOne("ServISData.Models.AdditionalEquipment", "AdditionalEquipment")
                        .WithMany("Photos")
                        .HasForeignKey("AdditionalEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalEquipment");
                });

            modelBuilder.Entity("ServISData.Models.AuctionBid", b =>
                {
                    b.HasOne("ServISData.Models.AuctionOffer", "AuctionOffer")
                        .WithMany()
                        .HasForeignKey("AuctionOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionOffer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServISData.Models.AuctionOffer", b =>
                {
                    b.HasOne("ServISData.Models.Excavator", "Excavator")
                        .WithMany()
                        .HasForeignKey("ExcavatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excavator");
                });

            modelBuilder.Entity("ServISData.Models.Excavator", b =>
                {
                    b.HasOne("ServISData.Models.ExcavatorType", "Type")
                        .WithMany("ExcavatorsOfThisType")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorPhoto", b =>
                {
                    b.HasOne("ServISData.Models.Excavator", "Excavator")
                        .WithMany("Photos")
                        .HasForeignKey("ExcavatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excavator");
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorProperty", b =>
                {
                    b.HasOne("ServISData.Models.Excavator", null)
                        .WithMany("Properties")
                        .HasForeignKey("ExcavatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.ExcavatorPropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorType", b =>
                {
                    b.HasOne("ServISData.Models.ExcavatorBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServISData.Models.ExcavatorCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServISData.Models.MainOffer", b =>
                {
                    b.HasOne("ServISData.Models.ExcavatorType", "ExcavatorType")
                        .WithMany()
                        .HasForeignKey("ExcavatorTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExcavatorType");
                });

            modelBuilder.Entity("ServISData.Models.AdditionalEquipment", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("ServISData.Models.Excavator", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("ServISData.Models.ExcavatorType", b =>
                {
                    b.Navigation("ExcavatorsOfThisType");
                });
#pragma warning restore 612, 618
        }
    }
}
