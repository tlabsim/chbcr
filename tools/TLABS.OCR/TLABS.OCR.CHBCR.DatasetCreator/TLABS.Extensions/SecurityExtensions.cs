using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TLABS.Extensions
{
    public static class SecurityExtensions
    {
        public static string Encrypt(this string string_to_encrypt, string key)
        {
            if (string_to_encrypt == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    return Crypto.Encrypt(string_to_encrypt, key);
                }
                catch { return string.Empty; }
            }
        }

        public static string Decrypt(this string encrypted_string, string key)
        {
            if (encrypted_string == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    return Crypto.Decrypt(encrypted_string, key);
                }
                catch { return string.Empty; }
            }
        }

        public static string EncryptDES(this string string_to_encrypt)
        {
            if (string_to_encrypt == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return DES.Encrypt(string_to_encrypt);
                
            }
        }

        public static string DecryptDES(this string encrypted_string)
        {
            if (encrypted_string == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    return DES.Decrypt(encrypted_string);
                }
                catch { return string.Empty; }
            }
        }
    }    

    // Code based on the book "C# 3.0 in a nutshell by Joseph Albahari" (pages 630-632)
    // and from this StackOverflow post by somebody called Brett
    // ht//stackoverflow.com/questions/202011/encrypt-decrypt-string-in-net/2791259#2791259
    static public class Crypto
    {
        private static readonly byte[] salt = Encoding.ASCII.GetBytes("[[[{{{(((Iftekhar Mahmud Towhid | im_towhid@yahoo.com)))}}}]]]");     

        public static string Encrypt(string textToEncrypt, string encryptionPassword)
        {
            var algorithm = GetAlgorithm(encryptionPassword);  
            byte[] encryptedBytes;
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                encryptedBytes = InMemoryCrypt(bytesToEncrypt, encryptor);
            }
            return Convert.ToBase64String(encryptedBytes);
        }     

        public static string Decrypt(string encryptedText, string encryptionPassword)
        {
            var algorithm = GetAlgorithm(encryptionPassword);    
            byte[] descryptedBytes;
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                descryptedBytes = InMemoryCrypt(encryptedBytes, decryptor);
            }
            return Encoding.UTF8.GetString(descryptedBytes);
        }     

        // Performs an in-memory encrypt/decrypt transformation on a byte array.
        private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
        {
            MemoryStream memory = new MemoryStream();
            using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }
            return memory.ToArray();
        }     

        // Defines a RijndaelManaged algorithm and sets its key and Initialization Vector (IV) 
        // values based on the encryptionPassword received.
        private static RijndaelManaged GetAlgorithm(string encryptionPassword)
        {
            // Create an encryption key from the encryptionPassword and salt.
            var key = new Rfc2898DeriveBytes(encryptionPassword, salt);   

            // Declare that we are going to use the Rijndael algorithm with the key that we've just got.
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIV = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIV);
            return algorithm;
        }

     

    }

    static public class DES
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("IMTOWHID");        

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the original string is null or empty.</exception>
        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        /// <summary>
        /// Decrypt a crypted string.
        /// </summary>
        /// <param name="cryptedString">The crypted string.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the crypted string is null or empty.</exception>
        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }
    }


}
