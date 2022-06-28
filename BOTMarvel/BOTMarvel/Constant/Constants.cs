using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BOTMarvel.Constant
{
    public class Constants
    {
        public static string addres = "https://localhost:7015";
        public static string apikey = "ts=1&apikey=46fa8863c46bd4938aa6a9da54e8b17c&hash=52e69e93347c9b5e406b1e72cf652b3b";

        public static string publicKey = "46fa8863c46bd4938aa6a9da54e8b17c";
        public static string privateKey = "ede1a53eee817e8f347d9d7781762502111407a5";
        public static string timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
        static string s = $"{timestamp}{privateKey}{publicKey}";
        public static string hash = CreateMD5Hash(s);


        private static string CreateMD5Hash(string input)
        {
            //MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            //Шіснадцяткова строка
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
