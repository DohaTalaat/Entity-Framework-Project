using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF_project
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Has> Hass { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Hass)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Permissions)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.c_cate);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.mail)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.E_Mail)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Fax)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Permissions)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.ID_Cust);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Mail)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.E_mail)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Permissions)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.num_Sup);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Person)
                .IsFixedLength();

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Hass)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Permissions)
                .WithOptional(e => e.Warehouse)
                .HasForeignKey(e => e.N_Ware);

            modelBuilder.Entity<Has>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .Property(e => e.num_Sup)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .Property(e => e.N_Ware)
                .IsFixedLength();
        }
    }
}
