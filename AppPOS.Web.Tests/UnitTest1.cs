using System;
using System.Diagnostics;
using System.Linq;
using AppPOS.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppPOS.Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new PosContext())
            {
                var karyawans = db.Mst_Karyawans.ToList();
                if (db.Mst_Karyawans.Any())
                {
                    foreach (var karyawan in karyawans)
                    {
                        Trace.WriteLine(string.Format("id:{0},No. Induk:{1},Nama Depan:{2}", karyawan.Id, karyawan.NoInduk, karyawan.NamaDepan));
                    }
                }
                else
                {
                    Trace.WriteLine("Data tidak tersedia");
                }
            }
        }
    }
}
