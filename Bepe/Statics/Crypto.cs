namespace IhandCashier.Bepe.Statics;
using System.Security.Cryptography;
using System.Text;

public static class Crypto
{
    // Metode untuk mengenkripsi data
    public static string Encrypt(string data, string key)
    {
        using (var aes = Aes.Create())
        {
            var keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.Key = keyBytes.Take(32).ToArray();
            aes.IV = keyBytes.Take(16).ToArray();

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    // Metode untuk mendekripsi data
    public static string Decrypt(string encryptedData, string key)
    {
        using (var aes = Aes.Create())
        {
            var keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32));
            aes.Key = keyBytes.Take(32).ToArray();
            aes.IV = keyBytes.Take(16).ToArray();

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream(Convert.FromBase64String(encryptedData)))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}