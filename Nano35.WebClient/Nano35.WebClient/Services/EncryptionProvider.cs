using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Nano35.WebClient.Services
{
    public interface IEncryptionProvider
    {
        Task<string> aes_Encrypt(string toEncrypt);
        Task<string> aes_Decrypt(string toDecrypt);

    }

    public class EncryptionProvider : IEncryptionProvider
    {
        private string _pass = "LPYuBK0f8s9KpzPIsLNHep1YImrs0I77";
        
    
    public async Task<string> aes_Encrypt(string toEncrypt)
    {
    //    var bytesToBeEncrypted = Encoding.UTF8.GetBytes(toEncrypt);
    //    var passwordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_pass));
    //    
        byte[] encryptedBytes = null;
    //
    //    var saltBytes = new byte[] { 5, 1, 9, 3, 8, 4, 3, 5 };
//
    //    using (var ms = new MemoryStream())
    //    {
    //        using (var aes = new AesCryptoServiceProvider())
    //        {
    //            aes.KeySize = 256;
    //            aes.BlockSize = 128;
    //
    //            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
    //            aes.Key = key.GetBytes(aes.KeySize / 8);
    //            aes.IV = key.GetBytes(aes.BlockSize / 8);
    //
    //            aes.Mode = CipherMode.CBC;
//
    //            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
    //            {
    //                cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
    //                cs.Close();
    //            }
    //            encryptedBytes = ms.ToArray();
    //            
    //            //ICryptoTransform cryptTransform = aes.CreateEncryptor();
    //            //encryptedBytes = cryptTransform.TransformFinalBlock(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
    //        }
    //    }
    //
        return Convert.ToBase64String(encryptedBytes);
    }
    
    public async Task<string> aes_Decrypt(string toDecrypt)
    {
        var bytesToBeDecrypted = Encoding.UTF8.GetBytes(toDecrypt);
        var passwordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_pass));
        
        byte[] decryptedBytes = null;
    
        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        var saltBytes = new byte[] { 5, 1, 9, 3, 8, 4, 3, 5 };

        await using (var ms = new MemoryStream())
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
    
                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
    
                aes.Mode = CipherMode.CBC;
    
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }
                decryptedBytes = ms.ToArray();
            }
        }
    
        return Encoding.UTF8.GetString(decryptedBytes);
    }

}
}