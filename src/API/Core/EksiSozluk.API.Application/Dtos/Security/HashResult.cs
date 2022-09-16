using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Security
{
    public class HashResult
    {
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }

        public HashResult()
        {

        }

        public HashResult(byte[] hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
