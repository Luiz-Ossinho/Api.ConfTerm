namespace Api.ConfTerm.Domain.Interfaces.Services
{
    public interface IHashingService
    {
        public byte[] GenerateSalt();
        public bool Compare(string plaintext, byte[] hash, byte[] salt);
        public byte[] GenerateHash(string plainText, byte[] salt);
    }
}
