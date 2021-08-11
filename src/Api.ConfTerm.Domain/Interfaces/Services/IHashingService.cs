using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ConfTerm.Core.Interfaces.Services
{
    public interface IHashingService
    {
        public byte[] GenerateSalt();
        public bool Compare(string plaintext, byte[] hash, byte[] salt);
        public byte[] GenerateHash(string plainText, byte[] salt);
    }
}
