using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SupplierList.Data.Model;

namespace SupplierList.Web.Migrations
{
    [DbContext(typeof(SupplierContext))]
    [Migration("20170903193425_03092017")]
    partial class _03092017
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SupplierList.Data.Model.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SupplierList.Data.Model.GroupSupplierBridge", b =>
                {
                    b.Property<int>("GroupSupplierBridgeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("SupplierId");

                    b.HasKey("GroupSupplierBridgeId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SupplierId");

                    b.ToTable("GroupsSuppliersBridge");
                });

            modelBuilder.Entity("SupplierList.Data.Model.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Phone");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SupplierList.Data.Model.UpdateHistory", b =>
                {
                    b.Property<string>("UpdateVersion")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Time");

                    b.HasKey("UpdateVersion");

                    b.ToTable("UpdateHistory");
                });

            modelBuilder.Entity("SupplierList.Data.Model.GroupSupplierBridge", b =>
                {
                    b.HasOne("SupplierList.Data.Model.Group", "Group")
                        .WithMany("Suppliers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SupplierList.Data.Model.Supplier", "Supplier")
                        .WithMany("Groups")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
