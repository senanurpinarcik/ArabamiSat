namespace ArabamiSatWeb.Helper_Codes
{
    public class Md5Helper
    {
        public static string CreateMd5(string input)
        { 
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);  
            }
        }
    }
}
