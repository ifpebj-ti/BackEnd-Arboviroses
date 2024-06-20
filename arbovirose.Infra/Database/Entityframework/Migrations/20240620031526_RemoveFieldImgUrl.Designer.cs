﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using arbovirose.Infra.Database.Entityframework;

#nullable disable

namespace arbovirose.Infra.Database.EntityFramework.Migrations
{
    [DbContext(typeof(ArboviroseContext))]
    [Migration("20240620031526_RemoveFieldImgUrl")]
    partial class RemoveFieldImgUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("arbovirose.Domain.Entities.InfoHomeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TitleLink")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Topic")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("InfoHome");
                });

            modelBuilder.Entity("arbovirose.Domain.Entities.ProfileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("Office", "arbovirose.Domain.Entities.ProfileEntity.Office#Office", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("arbovirose.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("PrimaryAccess")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "arbovirose.Domain.Entities.UserEntity.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("UniqueCode", "arbovirose.Domain.Entities.UserEntity.UniqueCode#UniqueCode", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("arbovirose.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("arbovirose.Domain.Entities.ProfileEntity", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("arbovirose.Domain.Entities.ProfileEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
