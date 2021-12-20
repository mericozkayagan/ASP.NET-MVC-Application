using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORIs.ToList();
            var degerler = db.TBLKATEGORIs.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORIs.Find(id);
            db.TBLKATEGORIs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORIs.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Kategorigetir(int id)
        {
            var ktgr = db.TBLKATEGORIs.Find(id);
            return View("Kategorigetir",ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORI p2)
        {
            var ktgr = db.TBLKATEGORIs.Find(p2.KATEGORIID);
            ktgr.KATEGORIAD = p2.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}