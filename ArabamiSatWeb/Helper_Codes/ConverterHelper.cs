namespace ArabamiSatWeb.Helper_Codes
{
    public static class ConverterHelper
    {
        public static int ToInt32(this object? deger, int defaultValue = -1)
        {
            if (deger.IsNullOrEmpty()) 
                return defaultValue; 
             
            bool result = int.TryParse(deger?.ToString(), out int number);
            if (result) 
                return number; 

            return defaultValue;
        }

        public static bool ToBoolean(this object? deger)
        {
            if (deger == null)
                return false;
            
            if (deger.IsNullOrEmpty())
                return false;
            
            if ((string)deger == "1" || deger == (object)1 || deger.ToString()?.ToLower() == "true" || (string)deger == "")
                return true;

            return false;
        }

        public static bool IsNullOrEmpty(this object? deger)
        {
            if (deger == null)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(deger.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}
