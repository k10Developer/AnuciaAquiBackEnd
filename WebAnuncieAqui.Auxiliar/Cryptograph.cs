using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebAnuciaAqui.Auxiliar
{
    public static class Cryptograph
    {
        public static string ComputeHashSh1(string value)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }

        }
        public static string HashFile(this string fileName)
        {

            using (var sha1 = SHA1.Create())
            {
                var buffer = File.ReadAllBytes(fileName);
                var hashBytes = sha1.ComputeHash(buffer);
                var stringHash = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringHash.AppendFormat("{0:X2}", hashBytes[i]);
                }

                return stringHash.ToString(); ;
            }

        }
        public static string RemoveAccentuation(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
