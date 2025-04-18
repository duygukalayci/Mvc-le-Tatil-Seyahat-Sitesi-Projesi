﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Sınıflar
{
	public class Yorumlar
	{
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }    //Blog özelliğinin türetilen sınıflarda (örneğin, bir subclass'ta) özelleştirilebilmesini sağlamaktır. Bu sayede, temel sınıftaki Blog özelliği gerektiğinde değiştirilip, özelleştirilebilir.

    }
}