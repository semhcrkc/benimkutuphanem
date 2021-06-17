using benim_kütüphanem.Models;
using benim_kütüphanem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace benim_kütüphanem.Controllers
{
    public class anaController : ApiController
    {
        benimkutuphanemDBEntities1 db = new benimkutuphanemDBEntities1();
        SonucModel sonuc = new SonucModel();

        [HttpGet]
        [Route("api/kitapHakkinda")]
        public List<kitapBModel> kitapHakkinda()
        {
            List<kitapBModel> liste = db.kitapBilgi.Select(x => new kitapBModel()
            {

                kitapId = x.kitapId,
                kitapAd = x.kitapAd,
                kitapYazar = x.kitapYazar,
                kitapYıl = x.kitapYıl,
                kitapSayfaSayisi = x.kitapSayfaSayisi,
                kitapYayinEvi = x.kitapYayinEvi,
                kitapDil = x.kitapDil,
                kitapAcıklama = x.kitapAcıklama


            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/adminHakkinda")]
        public List<adminBModel> adminHakkinda()
        {
            List<adminBModel> liste = db.adminBilgi.Select(x => new adminBModel()
            {

                adminId = x.adminId,
                adminAd = x.adminAd,
                adminSoyad = x.adminSoyad,
                adminSifre = x.adminSifre

            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/kategoriHakkinda")]
        public List<kategoriBModel> kategoriHakkinda()
        {
            List<kategoriBModel> liste = db.kategoriBilgi.Select(x => new kategoriBModel()
            {
                kategoriId = x.kategoriId,
                kategoriAd = x.kategoriAd

            }).ToList();
            return liste;
        }


        [HttpGet]
        [Route("api/üyeHakkinda")]
        public List<uyeBModel> üyeHakkinda()
        {
            List<uyeBModel> liste = db.üyeBilgi.Select(x => new uyeBModel()
            {

                uyeId = x.uyeId,
                uyeAd = x.uyeAd,
                uyeSoyad = x.uyeSoyad,
                uyeTelefon = x.uyeTelefon,
                uyePosta = x.uyePosta

            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/üyeOkunanKitapHakkinda")]
        public List<üyeKitapBModel> üyeOkunanKitapHakkinda()
        {
            List<üyeKitapBModel> liste = db.üyeKitapBilgi.Select(x => new üyeKitapBModel()
            {

                okunanKitaplarId = x.okunanKitaplarId,
                kitapAd = x.kitapAd,
                okunmaTarihi = x.okunmaTarihi,
                uyeId = x.uyeId,
                kitapId = x.kitapId

            }).ToList();
            return liste;
        }



        [HttpPost]
        [Route("api/kitapEkle")]
        public SonucModel KitapEkle(kitapBModel model)
        {
            if (db.kitapBilgi.Count(c => c.kitapAd == model.kitapAd) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen kitap adı mevcuttur!";
                return sonuc;
            }
            kitapBilgi yeni = new kitapBilgi();
            yeni.kitapAd = model.kitapAd;
            yeni.kitapYazar = model.kitapYazar;
            yeni.kitapYıl = model.kitapYıl;
            yeni.kitapSayfaSayisi = model.kitapSayfaSayisi;
            yeni.kitapYayinEvi = model.kitapYayinEvi;
            yeni.kitapDil = model.kitapDil;
            yeni.kitapAcıklama = model.kitapAcıklama;

            db.kitapBilgi.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Eklendi";

            return sonuc;

        }


        [HttpPost]
        [Route("api/adminEkle")]
        public SonucModel adminEkle(adminBModel model)
        {
            if (db.adminBilgi.Count(c => c.adminAd == model.adminAd) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen admin adı mevcuttur!";
                return sonuc;
            }
            adminBilgi yeni = new adminBilgi();
            yeni.adminAd = model.adminAd;
            yeni.adminSifre = model.adminSifre;
            yeni.adminSoyad = model.adminSoyad;

            db.adminBilgi.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Eklendi";

            return sonuc;
        }

        [HttpPost]
        [Route("api/uyeEkle")]
        public SonucModel uyeEkle(uyeBModel model)
        {
            if (db.üyeBilgi.Count(c => c.uyePosta == model.uyePosta) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu E-posta ile daha önce kayıt yapılmıştır!";
                return sonuc;
            }
            üyeBilgi yeni = new üyeBilgi();
            yeni.uyeId = model.uyeId;
            yeni.uyeAd = model.uyeAd;
            yeni.uyeSoyad = model.uyeSoyad;
            yeni.uyeTelefon = model.uyeTelefon;
            yeni.uyePosta = model.uyePosta;

            db.üyeBilgi.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Eklendi";

            return sonuc;
        }
        [HttpPost]
        [Route("api/uyeKEkle")]
        public SonucModel uyeKEkle(üyeKitapBModel model)
        {
            if (db.üyeKitapBilgi.Count(c => c.kitapAd == model.kitapAd) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Kitap Zaten Mevcut!";
                return sonuc;
            }
            üyeKitapBilgi yeni = new üyeKitapBilgi();
            yeni.okunanKitaplarId = model.okunanKitaplarId;
            yeni.kitapAd = model.kitapAd;
            yeni.okunmaTarihi = model.okunmaTarihi;
           

            db.üyeKitapBilgi.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Eklendi";

            return sonuc;
        }
        [HttpPut]
        [Route("api/kitapDuzenle")]
        public SonucModel kitapDuzenle(kitapBModel model)
        {
            kitapBilgi kayit = db.kitapBilgi.Where(s => s.kitapId == model.kitapId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.kitapId = model.kitapId;
            kayit.kitapAcıklama = model.kitapAcıklama;
            kayit.kitapAd = model.kitapAd;
            kayit.kitapDil = model.kitapDil;
            kayit.kitapSayfaSayisi = model.kitapSayfaSayisi;
            kayit.kitapYayinEvi = model.kitapYayinEvi;
            kayit.kitapYazar = model.kitapYazar;
            kayit.kitapYıl = model.kitapYıl;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kitap Düzenlendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/adminDuzenle")]
        public SonucModel adminDuzenle(adminBModel model)
        {
            adminBilgi kayit = db.adminBilgi.Where(s => s.adminId == model.adminId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.adminId = model.adminId;
            kayit.adminAd = model.adminAd;
            kayit.adminSoyad = model.adminSoyad;
            kayit.adminSifre = model.adminSifre;


            sonuc.islem = true;
            sonuc.mesaj = "Admin Düzenlendi";
            return sonuc;

        }

        [HttpPut]
        [Route("api/kategoriDuzenle")]
        public SonucModel kategoriDuzenle(kategoriBModel model)
        {
            kategoriBilgi kayit = db.kategoriBilgi.Where(s => s.kategoriId == model.kategoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.kategoriId = model.kategoriId;
            kayit.kategoriAd = model.kategoriAd;
           
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;
        }


        [HttpPut]
        [Route("api/uyeDuzenle")]
        public SonucModel uyeDuzenle(uyeBModel model)
        {
            üyeBilgi kayit = db.üyeBilgi.Where(s => s.uyeId == model.uyeId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.uyeId = model.uyeId;
            kayit.uyeAd = model.uyeAd;
            kayit.uyeSoyad = model.uyeSoyad;
            kayit.uyeTelefon = model.uyeTelefon;
            kayit.uyePosta = model.uyePosta;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Bilgisi Düzenlendi";
            return sonuc;
        }


        [HttpPut]
        [Route("api/üyeKitapDuzenle")]
        public SonucModel üyeKitapDuzenle(üyeKitapBModel model)
        {
            üyeKitapBilgi kayit = db.üyeKitapBilgi.Where(s => s.okunanKitaplarId == model.okunanKitaplarId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.okunanKitaplarId = model.okunanKitaplarId;
            kayit.kitapAd = model.kitapAd;
            kayit.okunmaTarihi = model.okunmaTarihi;
            kayit.uyeId = model.uyeId;
            kayit.kitapId = model.kitapId;

            sonuc.islem = true;
            sonuc.mesaj = "Okunan Kitap Bilgisi Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/adminSil/{adminId}")] 
        public SonucModel adminSil(int adminId)
        {
            adminBilgi kayit = db.adminBilgi.Where(s => s.adminId == adminId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.adminBilgi.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategoriSil/{kategoriId}")]
        public SonucModel kategoriSil(int kategoriId)
        {
            kategoriBilgi kayit = db.kategoriBilgi.Where(s => s.kategoriId == kategoriId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.kategoriBilgi.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kitapSil/{kitapId}")]
        public SonucModel kitapSil(int kitapId)
        {
            kitapBilgi kayit = db.kitapBilgi.Where(s => s.kitapId == kitapId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.kitapBilgi.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/üyeSil/{üyeId}")]
        public SonucModel üyeSil(int üyeId)
        {
            üyeBilgi kayit = db.üyeBilgi.Where(s => s.uyeId == üyeId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.üyeBilgi.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/üyeKitapSil/{okunanKitaplarId}")]
        public SonucModel üyeKitapSil(int okunanKitaplarId)
        {
            üyeKitapBilgi kayit = db.üyeKitapBilgi.Where(s => s.okunanKitaplarId == okunanKitaplarId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.üyeKitapBilgi.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi";

            return sonuc;
        }
















    }




}
