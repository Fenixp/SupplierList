using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SupplierList.Data.Model;

namespace SupplierList.Web.Migrations
{
    [DbContext(typeof(SupplierContext))]
    [Migration("20170902111920_02092017")]
    partial class _02092017
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

                    b.Property<string>("Name");

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

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("Phone");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
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
