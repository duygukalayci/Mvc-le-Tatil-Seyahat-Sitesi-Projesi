using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c=new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
           // var bloglar=c.Blogs.ToList();
           by.Deger1 = c.Blogs.ToList();
           by.Deger3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();

            return View(by);
        }
        /*
         * Controller, gelen HTTP isteklerini alır, işleme yapar ve uygun sonuçları (view'lar veya başka veriler) geri döner.
         * Context, muhtemelen bir veritabanı bağlamı (context) nesnesidir. Bu genellikle Entity Framework kullanarak veritabanı işlemleri yapmayı sağlar.
         * Context sınıfı, veritabanı ile iletişim kurmak için kullanılır ve burada c adında bir örneği oluşturulmuştur.
         * Bu nesne, veritabanındaki Blogs tablosuna erişimi sağlar.
         * 
         * c.Blogs ifadesi, veritabanındaki Blogs tablosunu temsil eder. Bu tablodaki tüm blogları almak için kullanılır.
         * ToList() metodu, veritabanındaki Blogs tablosundaki tüm kayıtları liste haline getirir.
         * Sonuçta, bloglar adında bir liste elde edilir ve bu listeyi View'a (görünüme) ileteceğiz.
         * özetle;
         * Bu controller, bir HTTP GET isteği aldığında veritabanından blogların listesini alır, bu listeyi Index görünümüne ileterek kullanıcıya blogları gösterir.
         */

        public ActionResult BlogDetay(int? id)
        {
            by.Deger1= c.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();
            //var blogbul=c.Blogs.Where(x =>x.Id==id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar b)
        {
            c.Yorumlars.Add(b);
            c.SaveChanges();
            return PartialView();
        }
    }
}