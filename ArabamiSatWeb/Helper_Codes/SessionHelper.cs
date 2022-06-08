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

        public static void EndSession()
        {
            HttpContext.Session.SetString(Constants.KULLANICI_ID, Constants.SESSION_NULL_VALUE);
            HttpContext.Session.SetString(Constants.AD_SOYAD, Constants.SESSION_NULL_VALUE);
            HttpContext.Session.SetString(Constants.YONETICI_MI, Constants.SESSION_NULL_VALUE);
        }

        public static int GetKullaniciId()
        {
            int kullaniciId = HttpContext.Session.GetString(Constants.KULLANICI_ID).ToInt32();
            return kullaniciId;
        }
        public static void SetKullaniciId(int kullaniciId)
        {
            HttpContext.Session.SetString(Constants.KULLANICI_ID, kullaniciId.ToString());
        }

        public static string GetAdSoyad()
        {
            string? adSoyad = HttpContext.Session.GetString(Constants.AD_SOYAD);
            return adSoyad ?? "";
        }
        public static void SetAdSoyad(string adSoyad)
        {
            HttpContext.Session.SetString(Constants.AD_SOYAD, adSoyad);
        }

        public static bool GetYoneticiMi()
        {
            bool yoneticiMi = HttpContext.Session.GetString(Constants.YONETICI_MI).ToBoolean();
            return yoneticiMi;
        }
        public static void SetYoneticiMi(bool yoneticiMi)
        {
            HttpContext.Session.SetString(Constants.YONETICI_MI, yoneticiMi.ToString());
        }

    }
}
