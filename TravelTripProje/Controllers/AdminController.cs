using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p)    //Bu metod, kullanıcı formu doldurup gönderdiğinde (yani POST isteği yaptığında) çalışır.

        {
            context.Blogs.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Kullanıcı /YeniBlog adresine gider(GET isteği), formu görür.
        //Formu doldurur ve gönderir (POST isteği).
        //Sunucu gelen verileri alır, veritabanına kaydeder ve kullanıcıyı Index sayfasına yönlendirir.

        public ActionResult BlogSil(int id)//silme işlemini idye göre yapacağız.
        {
            var b = context.Blogs.Find(id);//idden gelen degeri bul.
            context.Blogs.Remove(b);//bden gelen degeri sil.
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b1 = context.Blogs.Find(id);
            return View("BlogGetir", b1);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg=context.Blogs.Find(b.Id);
            blg.Baslik = b.Baslik;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b=context.Yorumlars.Find(id);
            context.Yorumlars.Remove(b);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var y = context.Yorumlars.Find(id);
            return View("YorumGetir", y);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = context.Yorumlars.Find(y.Id);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

       


    }
}