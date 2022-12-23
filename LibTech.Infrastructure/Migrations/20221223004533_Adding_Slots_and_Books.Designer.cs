﻿// <auto-generated />
using LibTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibTech.Infrastructure.Migrations
{
    [DbContext(typeof(LibTechContext))]
    [Migration("20221223004533_Adding_Slots_and_Books")]
    partial class AddingSlotsandBooks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibTech.Domain.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibTech.Domain.Slot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<long>("VendingMachineId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VendingMachineId");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("LibTech.Domain.VendingMachine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("Id");

                    b.ToTable("VendingMachines");
                });

            modelBuilder.Entity("LibTech.Domain.Slot", b =>
                {
                    b.HasOne("LibTech.Domain.VendingMachine", "VendingMachine")
                        .WithMany()
                        .HasForeignKey("VendingMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LibTech.Domain.BookPile", "BookPile", b1 =>
                        {
                            b1.Property<long>("SlotId")
                                .HasColumnType("bigint");

                            b1.Property<long>("BookId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Price");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int")
                                .HasColumnName("Quantity");

                            b1.HasKey("SlotId");

                            b1.HasIndex("BookId");

                            b1.ToTable("Slot");

                            b1.HasOne("LibTech.Domain.Book", "Book")
                                .WithMany()
                                .HasForeignKey("BookId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("SlotId");

                            b1.Navigation("Book");
                        });

                    b.Navigation("BookPile")
                        .IsRequired();

                    b.Navigation("VendingMachine");
                });

            modelBuilder.Entity("LibTech.Domain.VendingMachine", b =>
                {
                    b.OwnsOne("LibTech.Domain.Money", "MoneyInside", b1 =>
                        {
                            b1.Property<long>("VendingMachineId")
                                .HasColumnType("bigint");

                            b1.Property<int>("FiveDollarCount")
                                .HasColumnType("int")
                                .HasColumnName("FiveDollarCount");

                            b1.Property<int>("OneCentCount")
                                .HasColumnType("int")
                                .HasColumnName("OneCentCount");

                            b1.Property<int>("OneDollarCount")
                                .HasColumnType("int")
                                .HasColumnName("OneDollarCount");

                            b1.Property<int>("QuarterCount")
                                .HasColumnType("int")
                                .HasColumnName("QuarterCount");

                            b1.Property<int>("TenCentCount")
                                .HasColumnType("int")
                                .HasColumnName("TenCentCount");

                            b1.Property<int>("TwentyDollarCount")
                                .HasColumnType("int")
                                .HasColumnName("TwentyDollarCount");

                            b1.HasKey("VendingMachineId");

                            b1.ToTable("VendingMachines");

                            b1.WithOwner()
                                .HasForeignKey("VendingMachineId");
                        });

                    b.Navigation("MoneyInside")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
