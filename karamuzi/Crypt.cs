using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace karamuzi
{
    public class Crypt
    {
        public static string Hash(string password)
        {
            byte[] buffer;
            buffer = Encoding.UTF8.GetBytes(password);

            byte[] hashed;
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                hashed = provider.ComputeHash(buffer);
            }

            return Encoding.UTF8.GetString(hashed);
        }
    }
}