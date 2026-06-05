namespace PasswordVault.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
    }
}
