using System.Security.Cryptography;
using System.Text;

namespace DVideo.Core.Extentions
{
    public static class Extentions
    {
        public static string ToSha256(this string input)
        {
            using (SHA512 sha512 = new SHA512Managed())
            {
                var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }           
        }
    }
}