using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ZarateHash
    {
        public static int HashFunction(string input)
        {
            char[] inputFormatted = input.ToCharArray();
            int returnValue = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //arbitrary hash function
                returnValue += inputFormatted[i] * i * (5 * i);
            }

            return returnValue;
        }

    }
}


        /*
        public string PasswordSalt
        {
            get
            {
                var rng = new RNGCryptoServiceProvider();
                var buff = new byte[32];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);
            }
        }

        public string EncodePassword(string password, string salt)
        {
           

            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algo = HashAlgorithm.Create("SHA1");
            byte[] inArray = algo.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

    }

    */

