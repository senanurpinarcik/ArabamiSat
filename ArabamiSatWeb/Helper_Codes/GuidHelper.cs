namespace ArabamiSatWeb.Helper_Codes
{
    public class GuidHelper
    {
        public static string CreateShortGuid()
        {
            string shortGuid = Guid.NewGuid().ToString().Split('-').First().ToUpper();
            return shortGuid;
        }
    }
}
