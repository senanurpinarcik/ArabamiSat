using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
namespace ArabamiSatWeb.Helper_Codes
{
    public class SessionHelper
    {
        private static IHttpContextAccessor httpContextAccessor;

        public static IHttpContextAccessor GetHttpContextAccessor()
        {
            return httpContextAccessor;
        }

        public static void Configure(IHttpContextAccessor pHttpContextAccessor)
        {
            httpContextAccessor = pHttpContextAccessor;
        }
        public static HttpContext HttpContext
        {
            get { return httpContextAccessor?.HttpContext; }
        }

        public static void ClearSession()
        {
            HttpContext.Session.Clear();
        }

        public static int GetKullaniciId()
        {
            int kullaniciId = Convert.ToInt32(HttpContext.Session.GetString("KullaniciId"));

            return kullaniciId;
        }
        public static void SetKullaniciId(int kullaniciId)
        {
            HttpContext.Session.SetString("KullaniciId", kullaniciId.ToString());
        }
        public static string GetAdSoyad()
        {
            string adSoyad = HttpContext.Session.GetString("AdSoyad");
            return adSoyad;
        }
        public static void SetAdSoyad(string adSoyad)
        {
            HttpContext.Session.SetString("AdSoyad", adSoyad);
        }
        public static bool GetYoneticiMi()
        {
            bool yoneticiMi = Convert.ToBoolean(HttpContext.Session.GetString("YoneticiMi"));
            return yoneticiMi;
        }
        public static void SetYoneticiMi(bool yoneticiMi)
        {
            HttpContext.Session.SetString("YoneticiMi", yoneticiMi.ToString());
        }

    }
}
