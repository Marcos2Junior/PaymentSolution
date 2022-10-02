﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentSolution.Infrastructure;

#nullable disable

namespace PaymentSolution.Infrastructure.Migrations
{
    [DbContext(typeof(PaymentSolutionDataContext))]
    [Migration("20221001143514_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PaymentSolution.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentServiceID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentServiceID");

                    b.HasIndex("UserID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PaymentSolution.Domain.Entities.PaymentInstallment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Processed")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentID");

                    b.ToTable("PaymentInstallments");
                });

            modelBuilder.Entity("PaymentSolution.Domain.Entities.PaymentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("UseCertificate")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("WebHook")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PaymentServices");
                });

            modelBuilder.Entity("PaymentSolution.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTime = new DateTime(2022, 10, 1, 14, 35, 14, 572, DateTimeKind.Utc).AddTicks(8094),
                            Email = "mod.gluguer@gmail.com",
                            Name = "Marcos Antonio dos Santos Junior",
                            Password = "1ARVn2Auq2/WAqx2gNrL+q3RNjAzXpUfCXrzkA6d4Xa22yhRLy4AC50E+6UTPoscbo31nbOoq51gvkuXzJ6B2w=="
                        });
                });

            modelBuilder.Entity("PaymentSolution.Domain.Entities.Payment", b =>
                {
                    b.HasOne("PaymentSolution.Domain.Entities.PaymentService", "PaymentService")
                        .WithMany()
                        .HasForeignKey("PaymentServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentSolution.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PaymentSolution.Domain.Entities.PaymentInstallment", b =>
                {
                    b.HasOne("PaymentSolution.Domain.Entities.Payment", "Payment")
                        .WithMany("PaymentInstallments")
                        .HasForeignKey("PaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("PaymentSolution.Domain.Entities.Payment", b =>
                {
                    b.Navigation("PaymentInstallments");
                });
#pragma warning restore 612, 618
        }
    }
}
