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
            context.Mst_Karyawans.Add(new Karyawan { NoInduk = "00F002", NamaDepan = "Arief", NamaTengah = "Luthfi", NamaBelakang = "Aulia", Alamat = "Jalan Kehutanan No.10 majalengka 45411", TempatLahir = "Majalengka", TanggalLahir = new DateTime(1990, 4, 10), JenisKelamin = "L", IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Toko.Add(new Toko { Nama = "RL Group", Alamat = "Jalan Langsat 3 No. 5", NoTelp = "+6283876659905",CreatedBy = "Rio", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Pembeli.Add(new Pembeli { NoMember = "00M010", NamaDepan = "Rioneda", NamaTengah = "E", NamaBelakang = "Pratomo", Alamat = "Jalan Keremajaan no 1", TempatLahir = "Jakarta", TanggalLahir = new DateTime(1995, 4, 6), JenisKelamin = "L", IsActivated = true, CreatedBy = "Rio", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Barangs.Add(new Barang { Code = "AQU001", IdSupplier = 1, Deskripsi = "Air minum kemasan Aqua 250 ml", Harga = 500, Stok = 1000, IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_Barangs.Add(new Barang { Code = "AQU002", IdSupplier = 1, Deskripsi = "Air minum kemasan Aqua 600 ml", Harga = 350, Stok = 3000, IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_Barangs.Add(new Barang { Code = "BIM001", IdSupplier = 2, Deskripsi = "Minyak goreng bimoli 1 l", Harga = 13500, Stok = 100, IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.SaveChanges();

            context.Mst_Suppliers.Add(new Supplier { Nama = "PT. Aqua Golden Misisipi", Alamat = "Sukabumi", NoTelp = "+62251123456", IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
            context.Mst_Suppliers.Add(new Supplier { Nama = "PT. Bimoli Jaya", Alamat = "Serang", NoTelp = "+6223354321", IsActivated = true, CreatedBy = "Arief", CreatedDate = DateTime.Now });
  
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
