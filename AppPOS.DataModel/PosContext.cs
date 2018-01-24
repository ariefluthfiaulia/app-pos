using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    public class PosContext : DbContext
    {
        public PosContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Karyawan> Mst_Karyawans { get; set; }
        public DbSet<Toko> Mst_Toko { get; set; }
        public DbSet<Pembeli> Mst_Pembeli { get; set; }
        public DbSet<Barang> Mst_Barangs { get; set; }
        public DbSet<Supplier> Mst_Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasMany(p => p.Barangs)
                .WithRequired()
                .HasForeignKey(c => c.IdSupplier)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Barang>()
            //    .HasMany(p => p.DetailPembelians)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdBarang)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Barang>()
            //    .HasMany(p => p.DetailPenjualans)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdBarang)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Toko>()
            //    .HasMany(p => p.HeaderPembelians)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdToko)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Toko>()
            //    .HasMany(p => p.HeaderPenjualans)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdToko)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<HeaderPembelian>()
            //    .HasMany(p => p.DetailPembelians)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdHeaderPembelian)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<HeaderPenjualan>()
            //    .HasMany(p => p.DetailPenjualans)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdHeaderPenjualan)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Karyawan>()
            //    .HasMany(p => p.HeaderPembelians)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdKaryawan)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Karyawan>()
            //    .HasMany(p => p.HeaderPenjualans)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdKaryawan)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Pembeli>()
            //    .HasMany(p => p.HeaderPenjualans)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdPembeli)
            //    .WillCascadeOnDelete(false);
        }
    }
}
