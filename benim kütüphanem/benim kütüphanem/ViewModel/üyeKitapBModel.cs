using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benim_kütüphanem.ViewModel
{
    public class üyeKitapBModel
    {
        public int okunanKitaplarId { get; set; }
        public string kitapAd { get; set; }
        public Nullable<System.DateTime> okunmaTarihi { get; set; }
        public Nullable<int> uyeId { get; set; }
        public Nullable<int> kitapId { get; set; }

    }
}