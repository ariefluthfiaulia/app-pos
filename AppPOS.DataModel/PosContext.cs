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
        public DbSet<Toko> Mst_Tokos { get; set; }
        public DbSet<Pembeli> Mst_Pembelis { get; set; }
        public DbSet<Barang> Mst_Barangs { get; set; }
        public DbSet<DetailBarang> Mst_DetailBarangs { get; set; }
        public DbSet<Supplier> Mst_Suppliers { get; set; }
        public DbSet<HeaderPenjualan> Trans_HeaderPenjualans { get; set; }
        public DbSet<DetailPenjualan> Trans_DetailPenjualans { get; set; }
        public DbSet<HeaderPembelian> Trans_HeaderPembelians { get; set; }
        public DbSet<DetailPembelian> Trans_DetailPembelians { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>()
                .HasMany(p => p.DetailBarangs)
                .WithRequired()
                .HasForeignKey(c => c.IdBarang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Barang>()
                .HasMany(p => p.DetailPenjualans)
                .WithRequired()
                .HasForeignKey(c => c.IdBarang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(p => p.DetailBarangs)
                .WithRequired()
                .HasForeignKey(c => c.IdSupplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetailBarang>()
                .HasMany(p => p.DetailPembelians)
                .WithRequired()
                .HasForeignKey(c => c.IdDetailBarang)
                .WillCascadeOnDelete(false);

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

            //modelBuilder.Entity<Toko>()
            //    .HasMany(p => p.Karyawans)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdToko)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<HeaderPembelian>()
                .HasMany(p => p.DetailPembelians)
                .WithRequired()
                .HasForeignKey(c => c.IdHeaderPembelian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HeaderPenjualan>()
                .HasMany(p => p.DetailPenjualans)
                .WithRequired()
                .HasForeignKey(c => c.IdHeaderPenjualan)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Pembeli>()
                .HasMany(p => p.HeaderPenjualans)
                .WithRequired()
                .HasForeignKey(c => c.IdPembeli)
                .WillCascadeOnDelete(false);
        }
    }
}
