﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ValidationWithMediatr_task.Infrastructure.Presistence;

namespace ValidationWithMediatr_task.Infrastructure.Presistence.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ValidationWithMediatr_task.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("fullname")
                        .HasColumnType("text");

                    b.Property<int>("gender")
                        .HasColumnType("integer");

                    b.Property<string>("passowrd")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ValidationWithMediatr_task.Models.Customer_Payment_Card", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("credit_card_number")
                        .HasColumnType("text");

                    b.Property<int>("customer_id")
                        .HasColumnType("integer");

                    b.Property<string>("exp_month")
                        .HasColumnType("text");

                    b.Property<string>("exp_year")
                        .HasColumnType("text");

                    b.Property<string>("name_no_card")
                        .HasColumnType("text");

                    b.Property<int>("postal_code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.HasIndex("customer_id");

                    b.ToTable("Customer_Payment_Cards");
                });

            modelBuilder.Entity("ValidationWithMediatr_task.Models.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<double>("rating")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("ValidationWithMediatr_task.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("merchant_id")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.HasIndex("merchant_id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ValidationWithMediatr_task.Models.Customer_Payment_Card", b =>
                {
                    b.HasOne("ValidationWithMediatr_task.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValidationWithMediatr_task.Models.Product", b =>
                {
                    b.HasOne("ValidationWithMediatr_task.Models.Merchant", "merchant")
                        .WithMany()
                        .HasForeignKey("merchant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
