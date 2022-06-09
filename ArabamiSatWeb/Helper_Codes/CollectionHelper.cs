namespace ArabamiSatWeb.Helper_Codes
{
    public static class CollectionHelper
    {
        #region Base

        public static int Id(this IFormCollection collection)
        {
            int id = Convert.ToInt32(collection["Id"]);
            return id;
        }
        public static string Ad(this IFormCollection collection)
        {
            string ad = (collection["Ad"]);
            return ad;
        }
        public static string Soyad(this IFormCollection collection)
        {
            string soyad= (collection["Soyad"]);
            return soyad;
        }
        public static bool IkiFaktorluDogrulama(this IFormCollection collection)
        {
            bool dogrulama = collection["IkiFaktorluDogrulama"].ToBoolean();
            return dogrulama;
        }
        public static int Yas(this IFormCollection collection)
        {
            int yas = Convert.ToInt32(collection["Yas"]);
            return yas;
        }
        #endregion
        #region Special
        public static int MarkaId(this IFormCollection collection)
        {
            int markaId = Convert.ToInt32(collection["MarkaId"]);
            return markaId;
        }
        public static int MarkaModelId(this IFormCollection collection)
        {
            int markaModelId = Convert.ToInt32(collection["markaModelId"]);
            return markaModelId;
        }
        #endregion
    }
}
