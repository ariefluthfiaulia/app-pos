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
                var barangs = db.Mst_Barangs.ToList();
                if (db.Mst_Barangs.Any())
                {
                    foreach (var barang in barangs)
                    {
                        Trace.WriteLine(string.Format("id:{0},Deskripsi:{1}", barang.Id, barang.Deskripsi));
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
