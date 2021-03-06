﻿// <auto-generated />
using System;
using BVS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BVS.Migrations
{
    [DbContext(typeof(BVSDBContext))]
    [Migration("20190519120052_fixingMultiplicity")]
    partial class fixingMultiplicity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BVS.Data.Models.ATM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AditionalInfo");

                    b.Property<bool>("Online");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("ATMs");
                });

            modelBuilder.Entity("BVS.Data.Models.ATM_Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("atmMessages");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ATM_Message");
                });

            modelBuilder.Entity("BVS.Data.Models.ATM_Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ATM_Parts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ATM_Part");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Description of patr1",
                            Name = "Part1"
                        });
                });

            modelBuilder.Entity("BVS.Data.Models.ATM_Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtmId");

                    b.Property<string>("NewAddress");

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("Id");

                    b.HasIndex("AtmId");

                    b.ToTable("ATM_Transports");
                });

            modelBuilder.Entity("BVS.Data.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("MessageId");

                    b.Property<int>("State");

                    b.Property<int?>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique()
                        .HasFilter("[MessageId] IS NOT NULL");

                    b.HasIndex("WorkerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("BVS.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArivalDate");

                    b.Property<int>("AuthorId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BVS.Data.Models.OrderedPart", b =>
                {
                    b.Property<int>("PartId");

                    b.Property<int>("OrderId");

                    b.Property<float>("Price");

                    b.HasKey("PartId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderedPart");
                });

            modelBuilder.Entity("BVS.Data.Models.PartInStorage", b =>
                {
                    b.Property<int>("PartId");

                    b.Property<int>("RackId");

                    b.Property<int>("Count");

                    b.HasKey("PartId", "RackId");

                    b.HasIndex("RackId");

                    b.ToTable("PartInStorage");
                });

            modelBuilder.Entity("BVS.Data.Models.Rack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("BVS.Data.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<bool>("Completed");

                    b.Property<DateTime>("Date");

                    b.Property<int>("JobId");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("BVS.Data.Models.Subscription", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ATMId");

                    b.HasKey("UserId", "ATMId");

                    b.HasIndex("ATMId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("BVS.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("BVS.Data.Models.UserReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserReports");
                });

            modelBuilder.Entity("BVS.Data.Models.AttentionNeededMessage", b =>
                {
                    b.HasBaseType("BVS.Data.Models.ATM_Message");

                    b.HasDiscriminator().HasValue("AttentionNeededMessage");
                });

            modelBuilder.Entity("BVS.Data.Models.InformationalMessage", b =>
                {
                    b.HasBaseType("BVS.Data.Models.ATM_Message");

                    b.Property<string>("Body");

                    b.HasDiscriminator().HasValue("InformationalMessage");
                });

            modelBuilder.Entity("BVS.Data.Models.Cartridge", b =>
                {
                    b.HasBaseType("BVS.Data.Models.ATM_Part");

                    b.Property<float>("Nominal");

                    b.HasDiscriminator().HasValue("Cartridge");

                    b.HasData(
                        new
                        {
                            Id = -2,
                            Description = "Description of cartridge1",
                            Name = "Cartridge1",
                            Nominal = 50f
                        });
                });

            modelBuilder.Entity("BVS.Data.Models.Administrator", b =>
                {
                    b.HasBaseType("BVS.Data.Models.User");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "karolis.breidokas@ktu.edu",
                            Name = "Karolis",
                            Password = "$2a$10$wXKjdScgnoSGL6jFFDxSD.pngMcqRZZaPyRpUYFX7kdV/964qMMGe",
                            Surname = "Breidokas",
                            Username = "Root"
                        });
                });

            modelBuilder.Entity("BVS.Data.Models.StorageWorker", b =>
                {
                    b.HasBaseType("BVS.Data.Models.User");

                    b.Property<string>("PhoneNo");

                    b.HasDiscriminator().HasValue("StorageWorker");
                });

            modelBuilder.Entity("BVS.Data.Models.Worker", b =>
                {
                    b.HasBaseType("BVS.Data.Models.User");

                    b.Property<string>("PhoneNo")
                        .HasColumnName("Worker_PhoneNo");

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("BVS.Data.Models.EmptyCasseteMessage", b =>
                {
                    b.HasBaseType("BVS.Data.Models.AttentionNeededMessage");

                    b.Property<int>("CartridgeId")
                        .HasColumnName("PartId");

                    b.HasIndex("CartridgeId");

                    b.ToTable("EmptyCasseteMessages");

                    b.HasDiscriminator().HasValue("EmptyCasseteMessage");
                });

            modelBuilder.Entity("BVS.Data.Models.PartBrokenMessage", b =>
                {
                    b.HasBaseType("BVS.Data.Models.AttentionNeededMessage");

                    b.Property<int>("PartId")
                        .HasColumnName("PartId");

                    b.HasIndex("PartId")
                        .HasName("IX_atmMessages_PartId1");

                    b.ToTable("PartBroken");

                    b.HasDiscriminator().HasValue("PartBrokenMessage");
                });

            modelBuilder.Entity("BVS.Data.Models.ATM_Message", b =>
                {
                    b.HasOne("BVS.Data.Models.ATM", "Autor")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.ATM_Transport", b =>
                {
                    b.HasOne("BVS.Data.Models.ATM", "Transported")
                        .WithMany("Transportations")
                        .HasForeignKey("AtmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.Job", b =>
                {
                    b.HasOne("BVS.Data.Models.AttentionNeededMessage", "Reason")
                        .WithOne()
                        .HasForeignKey("BVS.Data.Models.Job", "MessageId");

                    b.HasOne("BVS.Data.Models.Worker", "AssignedWorker")
                        .WithMany("AssignedJobs")
                        .HasForeignKey("WorkerId");
                });

            modelBuilder.Entity("BVS.Data.Models.Order", b =>
                {
                    b.HasOne("BVS.Data.Models.StorageWorker", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.OrderedPart", b =>
                {
                    b.HasOne("BVS.Data.Models.Order", "Order")
                        .WithMany("Parts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BVS.Data.Models.ATM_Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.PartInStorage", b =>
                {
                    b.HasOne("BVS.Data.Models.ATM_Part", "parts")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BVS.Data.Models.Rack", "racks")
                        .WithMany()
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.Report", b =>
                {
                    b.HasOne("BVS.Data.Models.Job", "Job")
                        .WithMany("Reports")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BVS.Data.Models.Worker", "Author")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.Subscription", b =>
                {
                    b.HasOne("BVS.Data.Models.ATM", "SubscribedATM")
                        .WithMany()
                        .HasForeignKey("ATMId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BVS.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.UserReport", b =>
                {
                    b.HasOne("BVS.Data.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.EmptyCasseteMessage", b =>
                {
                    b.HasOne("BVS.Data.Models.Cartridge", "Cartridge")
                        .WithMany()
                        .HasForeignKey("CartridgeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BVS.Data.Models.PartBrokenMessage", b =>
                {
                    b.HasOne("BVS.Data.Models.ATM_Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .HasConstraintName("FK_atmMessages_ATM_Parts_PartId1")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
