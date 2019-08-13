using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<PosContext>
    {
        public override void InitializeDatabase(PosContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(PosContext context)
        {
            context.Mst_Suppliers.Add(new Supplier { Nama = "PT. Aqua Golden Misisipi", Alamat = "Sukabumi", NoTelp = "+62251123456", IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_Suppliers.Add(new Supplier { Nama = "PT. Bimoli Jaya", Alamat = "Serang", NoTelp = "+6223354321", IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });

            context.SaveChanges();

            context.Mst_Barangs.Add(new Barang { Code = "AQU001",  Deskripsi = "Air minum kemasan Aqua 250 ml", HargaPenjualan=1000, Stok=100,  IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_Barangs.Add(new Barang { Code = "AQU002",  Deskripsi = "Air minum kemasan Aqua 600 ml", HargaPenjualan=3500, Stok=100,  IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_Barangs.Add(new Barang { Code = "BIM001",  Deskripsi = "Minyak goreng bimoli 1 l", HargaPenjualan=13500, Stok=50,  IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_DetailBarangs.Add(new DetailBarang { IdBarang = 1, IdSupplier =1,   HargaPembelian = 500, IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_DetailBarangs.Add(new DetailBarang { IdBarang = 1, IdSupplier = 2,  HargaPembelian = 650, IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_DetailBarangs.Add(new DetailBarang { IdBarang = 2, IdSupplier = 1, HargaPembelian = 3000,  IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_DetailBarangs.Add(new DetailBarang { IdBarang = 3, IdSupplier = 2,  HargaPembelian = 13000, IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Karyawans.Add(new Karyawan { NoInduk = "00F002", NamaDepan = "Arief", NamaTengah = "Luthfi", NamaBelakang = "Aulia", Alamat = "Jalan Kehutanan No.10 majalengka 45411", TempatLahir = "Majalengka", TanggalLahir = new DateTime(1990, 4, 10), JenisKelamin = "L", IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Tokos.Add(new Toko { Nama = "RL Group", Alamat = "Jalan Langsat 3 No. 5", NoTelp = "+6283876659905",CreatedBy = "Rio", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Pembelis.Add(new Pembeli { NoMember = "00M001", NamaDepan = "Rioneda", NamaTengah = "E", NamaBelakang = "Pratomo", Alamat = "Jalan Keremajaan no 1", TempatLahir = "Jakarta", TanggalLahir = new DateTime(1995, 4, 6), JenisKelamin = "L", IsActivated = true, CreatedBy = "Rio", CreatedDate = DateTime.Now });
            context.Mst_Pembelis.Add(new Pembeli { NoMember = "00M002", NamaDepan = "Atur",  NamaBelakang = "Aritonang", Alamat = "Kebun Jeruk", TempatLahir = "Medan", TanggalLahir = new DateTime(1970, 4, 10), JenisKelamin = "L", IsActivated = true, CreatedBy = "Rio", CreatedDate = DateTime.Now });
            context.Mst_Pembelis.Add(new Pembeli { NoMember = "00M003", NamaDepan = "Ndi", NamaTengah = "Markus", NamaBelakang = "Wijaya", Alamat = "Kebayoran", TempatLahir = "Jakarta", TanggalLahir = new DateTime(1983, 8, 6), JenisKelamin = "L", IsActivated = true, CreatedBy = "Rio", CreatedDate = DateTime.Now });
            context.SaveChanges();

            

            

            base.Seed(context);
        }
    }
}
