﻿// <auto-generated />
using System;
using BServisData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BServisData.Migrations
{
    [DbContext(typeof(BServisDbContext))]
    partial class BServisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("BServisData.Models.AdditionalEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ForWhichExcavatorCategory")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdditionalEquipments");
                });

            modelBuilder.Entity("BServisData.Models.AdditionalEquipmentPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AdditionalEquipmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTitle")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(4000)");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalEquipmentId");

                    b.ToTable("AdditionalEquipmentPhotos");
                });

            modelBuilder.Entity("BServisData.Models.AuctionBid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AuctionOfferId")
                        .HasColumnType("int");

                    b.Property<int>("Bid")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionOfferId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionBids");
                });

            modelBuilder.Entity("BServisData.Models.AuctionOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ExcavatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OfferEnd")
                        .HasColumnType("datetime");

                    b.Property<int>("StartingBid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorId");

                    b.ToTable("AuctionOffers");
                });

            modelBuilder.Entity("BServisData.Models.Excavator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsNew")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastInspection")
                        .HasColumnType("datetime");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Excavators");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Excavator");
                });

            modelBuilder.Entity("BServisData.Models.ExcavatorPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ExcavatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTitle")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(4000)");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorId");

                    b.ToTable("ExcavatorPhotos");
                });

            modelBuilder.Entity("BServisData.Models.SparePart", b =>
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

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("BServisData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("ExcavatorSparePart", b =>
                {
                    b.Property<int>("ExcavatorsId")
                        .HasColumnType("int");

                    b.Property<int>("SparePartsId")
                        .HasColumnType("int");

                    b.HasKey("ExcavatorsId", "SparePartsId");

                    b.HasIndex("SparePartsId");

                    b.ToTable("ExcavatorSparePart");
                });

            modelBuilder.Entity("BServisData.Models.SkidSteerLoader", b =>
                {
                    b.HasBaseType("BServisData.Models.Excavator");

                    b.Property<int>("AcousticNoisePowerDb")
                        .HasColumnType("int");

                    b.Property<string>("BucketLeveling")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Control")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ControlType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DriveControlHydrogenerator")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DriveType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("ElectricalInstallationV")
                        .HasColumnType("int");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("HeightMm")
                        .HasColumnType("int");

                    b.Property<float>("IncreasedBucketVolumeM3")
                        .HasColumnType("float");

                    b.Property<int>("LengthWithBucketMm")
                        .HasColumnType("int");

                    b.Property<float>("LiftingForceKn")
                        .HasColumnType("float");

                    b.Property<int>("MaximumDischargeHeightMm")
                        .HasColumnType("int");

                    b.Property<int>("NominalLoadCapacityKg")
                        .HasColumnType("int");

                    b.Property<float>("OperatingControlPressureMpa")
                        .HasColumnType("float");

                    b.Property<int>("OperatingHydraulicFlowLpm")
                        .HasColumnType("int");

                    b.Property<float>("OperatingPressureMpa")
                        .HasColumnType("float");

                    b.Property<int>("OverloadPointKg")
                        .HasColumnType("int");

                    b.Property<float>("RatedPowerKw")
                        .HasColumnType("float");

                    b.Property<int>("ReachMm")
                        .HasColumnType("int");

                    b.Property<float>("StandardTiresMax")
                        .HasColumnType("float");

                    b.Property<float>("StandardTiresMin")
                        .HasColumnType("float");

                    b.Property<float>("TearingStrengthKn")
                        .HasColumnType("float");

                    b.Property<float>("TopSpeedKmh")
                        .HasColumnType("float");

                    b.Property<float?>("TopSpeedKmhSpeedVersionMax")
                        .HasColumnType("float");

                    b.Property<float?>("TopSpeedKmhSpeedVersionMin")
                        .HasColumnType("float");

                    b.Property<float>("TractionForceKn")
                        .HasColumnType("float");

                    b.Property<float?>("TractionForceKnSpeedVersion")
                        .HasColumnType("float");

                    b.Property<string>("VehicleHydraulicMotor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<float>("VehicleHydraulicMotorOperatingPressureMpa")
                        .HasColumnType("float");

                    b.Property<int>("WeightKg")
                        .HasColumnType("int");

                    b.Property<int>("WidthWithBucketMm")
                        .HasColumnType("int");

                    b.Property<string>("WorkEquipmentHydrogenerator")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("WorkEquipmentSwitchboard")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasDiscriminator().HasValue("SkidSteerLoader");
                });

            modelBuilder.Entity("BServisData.Models.TrackedExcavator", b =>
                {
                    b.HasBaseType("BServisData.Models.Excavator");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("ExcavationDepthMm")
                        .HasColumnType("int");

                    b.Property<float>("HydraulicFlowLpm")
                        .HasColumnType("float");

                    b.Property<float>("MaximumPowerKw")
                        .HasColumnType("float");

                    b.Property<int>("MaximumWidthMm")
                        .HasColumnType("int");

                    b.Property<int>("OperatingPressureBar")
                        .HasColumnType("int");

                    b.Property<int>("OperatingWeightKg")
                        .HasColumnType("int");

                    b.Property<int>("PenetrationForceKg")
                        .HasColumnType("int");

                    b.Property<int>("TearingStrengthKg")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TrackedExcavator");
                });

            modelBuilder.Entity("BServisData.Models.TrackedLoader", b =>
                {
                    b.HasBaseType("BServisData.Models.Excavator");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("TrackedLoader_Engine");

                    b.Property<float?>("HydraulicFlowHiFlowLpm")
                        .HasColumnType("float");

                    b.Property<float>("HydraulicFlowLpm")
                        .HasColumnType("float")
                        .HasColumnName("TrackedLoader_HydraulicFlowLpm");

                    b.Property<int>("MaximumOperatingPressureBar")
                        .HasColumnType("int");

                    b.Property<float>("MaximumPowerKw")
                        .HasColumnType("float")
                        .HasColumnName("TrackedLoader_MaximumPowerKw");

                    b.Property<int>("OperatingLoadCapacityIso14397Kg")
                        .HasColumnType("int");

                    b.Property<int>("OperatingWeightKg")
                        .HasColumnType("int")
                        .HasColumnName("TrackedLoader_OperatingWeightKg");

                    b.Property<float>("StandardBucketVolumeM3")
                        .HasColumnType("float");

                    b.Property<int>("TiltingLoadKg")
                        .HasColumnType("int");

                    b.Property<int>("TrackWidthMm")
                        .HasColumnType("int");

                    b.Property<float>("TractionForceKn")
                        .HasColumnType("float")
                        .HasColumnName("TrackedLoader_TractionForceKn");

                    b.HasDiscriminator().HasValue("TrackedLoader");
                });

            modelBuilder.Entity("BServisData.Models.Administrator", b =>
                {
                    b.HasBaseType("BServisData.Models.User");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("BServisData.Models.Customer", b =>
                {
                    b.HasBaseType("BServisData.Models.User");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(17)
                        .HasColumnType("varchar(17)");

                    b.Property<string>("Residence")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("BServisData.Models.AdditionalEquipmentPhoto", b =>
                {
                    b.HasOne("BServisData.Models.AdditionalEquipment", "AdditionalEquipment")
                        .WithMany()
                        .HasForeignKey("AdditionalEquipmentId");

                    b.Navigation("AdditionalEquipment");
                });

            modelBuilder.Entity("BServisData.Models.AuctionBid", b =>
                {
                    b.HasOne("BServisData.Models.AuctionOffer", "AuctionOffer")
                        .WithMany()
                        .HasForeignKey("AuctionOfferId");

                    b.HasOne("BServisData.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AuctionOffer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BServisData.Models.AuctionOffer", b =>
                {
                    b.HasOne("BServisData.Models.Excavator", "Excavator")
                        .WithMany()
                        .HasForeignKey("ExcavatorId");

                    b.Navigation("Excavator");
                });

            modelBuilder.Entity("BServisData.Models.ExcavatorPhoto", b =>
                {
                    b.HasOne("BServisData.Models.Excavator", "Excavator")
                        .WithMany()
                        .HasForeignKey("ExcavatorId");

                    b.Navigation("Excavator");
                });

            modelBuilder.Entity("ExcavatorSparePart", b =>
                {
                    b.HasOne("BServisData.Models.Excavator", null)
                        .WithMany()
                        .HasForeignKey("ExcavatorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BServisData.Models.SparePart", null)
                        .WithMany()
                        .HasForeignKey("SparePartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
