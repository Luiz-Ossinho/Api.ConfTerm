using Api.ConfTerm.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Api.ConfTerm.Application.Services
{
    public class HashingService : IHashingService
    {
        //private readonly string Charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789" + "!&@#";

        public bool Compare(string plaintext, byte[] hash, byte[] salt)
        {
            return hash.SequenceEqual(GenerateHash(plaintext, salt));
        }

        public byte[] GenerateHash(string plainText, byte[] salt)
        {
            using var algorithm = new SHA256Managed();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainText).Concat(salt).ToArray());
        }

        public byte[] GenerateSalt()
        {
            using var RNG = new RNGCryptoServiceProvider();
            var bytes = new byte[16];
            RNG.GetBytes(bytes);
            return bytes;
        }
    }
}
