using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benim_kütüphanem.ViewModel
{
    public class kitapBModel
    {
        public int kitapId { get; set; }
        public string kitapAd { get; set; }
        public string kitapYazar { get; set; }
        public Nullable<System.DateTime> kitapYıl { get; set; }
        public Nullable<int> kitapSayfaSayisi { get; set; }
        public string kitapYayinEvi { get; set; }
        public string kitapDil { get; set; }
        public string kitapAcıklama { get; set; }
    }
}