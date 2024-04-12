﻿// <auto-generated />
using System;
using DDDwithMediatR.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDDwithMediatR.Migrations
{
    [DbContext(typeof(AdventureWorksDataContext))]
    partial class AdventureWorksDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DDDwithMediatR.Domain_Layer.Models.BusinessEntity", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessEntityID"));

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("rowguid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BusinessEntityID");

                    b.ToTable("BusinessEntity", "Person");
                });

            modelBuilder.Entity("DDDwithMediatR.Domain_Layer.Person", b =>
                {
                    b.Property<int>("BusinessEntityID")
                        .HasColumnType("int");

                    b.Property<int>("EmailPromotion")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NameStyle")
                        .HasColumnType("bit");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("rowguid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BusinessEntityID");

                    b.ToTable("Person", "Person");
                });

            modelBuilder.Entity("DDDwithMediatR.Domain_Layer.Person", b =>
                {
                    b.HasOne("DDDwithMediatR.Domain_Layer.Models.BusinessEntity", null)
                        .WithOne("Person")
                        .HasForeignKey("DDDwithMediatR.Domain_Layer.Person", "BusinessEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DDDwithMediatR.Domain_Layer.Models.BusinessEntity", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}