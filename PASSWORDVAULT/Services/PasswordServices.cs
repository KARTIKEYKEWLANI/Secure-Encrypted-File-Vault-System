using PasswordVault.Models;
using PasswordVault.Data;
using System.Security.Cryptography;
using System.Text;

namespace PasswordVault.Services

{
    public class PasswordService
    {
        private readonly AppDbContext _context;
        private readonly string _encryptionKey = "Kartik@EncryptionKey123";

        public PasswordService()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        public void AddCredential(string site, string username, string password)
        {
            var encrypted = Encrypt(password);
            var cred = new Credential { Site = site, Username = username, EncryptedPassword = encrypted };
            _context.Credentials.Add(cred);
            _context.SaveChanges();
            Console.WriteLine("Credential saved.");
        }

        public void ViewAll()
        {
            var creds = _context.Credentials.ToList();
            if (creds.Count == 0)
            {
                Console.WriteLine("No credentials stored.");
                return;
            }

            Console.WriteLine("\nSTORED CREDENTIALS:");
            foreach (var cred in creds)
            {
                string decrypted = Decrypt(cred.EncryptedPassword);
                Console.WriteLine($"{cred.Site} | {cred.Username} | {decrypted}");
            }
        }

        public void DeleteCredential(string site)
        {
            var item = _context.Credentials.FirstOrDefault(c => c.Site == site);
            if (item != null)
            {
                _context.Credentials.Remove(item);
                _context.SaveChanges();
                Console.WriteLine(" Credential deleted.");
            }
            else Console.WriteLine("⚠ Site not found.");
        }

        private string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(_encryptionKey));
            aes.GenerateIV();
            var iv = aes.IV;

            using var ms = new MemoryStream();
            ms.Write(iv, 0, iv.Length);
            using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);

            return Convert.ToBase64String(ms.ToArray());
        }

        private string Decrypt(string encrypted)
        {
            var fullCipher = Convert.FromBase64String(encrypted);
            using Aes aes = Aes.Create();
            aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(_encryptionKey));

            byte[] iv = new byte[16];
            Array.Copy(fullCipher, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using var ms = new MemoryStream(fullCipher, 16, fullCipher.Length - 16);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        public List<(string Site, string Username, string Password)> GetCredentials()
        {
            return _context.Credentials.ToList()
                .Select(c => (c.Site, c.Username, Decrypt(c.EncryptedPassword)))
                .ToList();
        }

        internal IEnumerable<object> GetAllCredentials()
        {
            throw new NotImplementedException();
        }
    }
}
