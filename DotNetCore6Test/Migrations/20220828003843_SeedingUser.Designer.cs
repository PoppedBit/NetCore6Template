﻿// <auto-generated />
using System;
using DotNetCore6Test.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetCore6Test.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220828003843_SeedingUser")]
    partial class SeedingUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DotNetCore6Test.Entities.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a8ce4c1-20d7-4ec5-874a-7793d03fee90"),
                            Email = "test@test.com",
                            FirstName = "First",
                            IsAdmin = true,
                            LastName = "Last",
                            PasswordHash = new byte[] { 79, 111, 252, 32, 50, 99, 51, 55, 31, 211, 253, 75, 54, 10, 130, 186, 178, 240, 200, 104, 11, 169, 93, 211, 55, 60, 189, 72, 43, 27, 247, 138, 159, 137, 88, 63, 167, 208, 61, 69, 109, 122, 93, 61, 134, 203, 106, 223, 112, 165, 121, 97, 137, 125, 2, 19, 218, 194, 231, 203, 140, 250, 93, 175 },
                            PasswordSalt = new byte[] { 171, 232, 11, 186, 255, 210, 38, 77, 159, 150, 30, 138, 254, 150, 45, 82, 185, 144, 139, 4, 29, 203, 58, 34, 24, 203, 66, 23, 8, 187, 229, 163, 130, 156, 124, 128, 232, 84, 150, 188, 31, 24, 94, 70, 188, 247, 145, 78, 159, 160, 212, 59, 39, 244, 105, 79, 164, 219, 85, 126, 200, 250, 21, 56, 28, 188, 94, 20, 181, 46, 189, 69, 162, 182, 156, 171, 129, 176, 164, 139, 164, 7, 225, 30, 195, 212, 211, 221, 151, 161, 53, 2, 25, 112, 241, 186, 65, 247, 142, 156, 100, 52, 20, 236, 2, 134, 182, 58, 8, 22, 150, 240, 187, 134, 207, 91, 154, 194, 242, 6, 105, 5, 234, 180, 7, 203, 46, 210 },
                            Username = ""
                        });
                });

            modelBuilder.Entity("DotNetCore6Test.Entities.Auth.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LoginTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
