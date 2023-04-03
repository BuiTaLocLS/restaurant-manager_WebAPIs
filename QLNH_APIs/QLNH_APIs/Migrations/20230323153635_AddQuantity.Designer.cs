﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLNH_APIs.Data;

namespace QLNH_APIs.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230323153635_AddQuantity")]
    partial class AddQuantity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QLNH_APIs.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ItemImageId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("QLNH_APIs.Models.GuestTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GuestId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("GuestId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("GuestTable");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("FoodId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("SizeId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("QLNH_APIs.Models.ItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("ItemImage");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Voided")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("QLNH_APIs.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Voided")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UnitIdentity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("QLNH_APIs.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OffDuty")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Category", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Food", b =>
                {
                    b.HasOne("QLNH_APIs.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.ItemImage", "ItemImage")
                        .WithMany()
                        .HasForeignKey("ItemImageId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("Category");

                    b.Navigation("CreatedUser");

                    b.Navigation("ItemImage");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Guest", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.GuestTable", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("QLNH_APIs.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Guest");

                    b.Navigation("Location");

                    b.Navigation("Restaurant");

                    b.Navigation("Status");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Item", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Food");

                    b.Navigation("Restaurant");

                    b.Navigation("Size");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.ItemImage", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Location", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Order", b =>
                {
                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QLNH_APIs.Models.OrderItem", b =>
                {
                    b.HasOne("QLNH_APIs.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("QLNH_APIs.Models.Order", null)
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Item");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Restaurant", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Role", b =>
                {
                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Size", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("Unit");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Status", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Unit", b =>
                {
                    b.HasOne("QLNH_APIs.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QLNH_APIs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QLNH_APIs.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QLNH_APIs.Models.User", b =>
                {
                    b.HasOne("QLNH_APIs.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("QLNH_APIs.Models.User", null)
                        .WithMany("UpdatedUser")
                        .HasForeignKey("UserId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QLNH_APIs.Models.Order", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("QLNH_APIs.Models.User", b =>
                {
                    b.Navigation("UpdatedUser");
                });
#pragma warning restore 612, 618
        }
    }
}
