using System.Security.Cryptography;
using System.Text;

namespace Define.Common.Extension.Methods
{
    public class PasswordHash
    {
        public static string CreatePasswordHash(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
