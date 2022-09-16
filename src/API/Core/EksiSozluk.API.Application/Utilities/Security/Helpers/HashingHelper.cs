using EksiSozluk.API.Application.Dtos.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Security.Helpers
{
    public class HashingHelper
    {
        public static HashResult ComputeHashByKey(String value)
        {
            using (var algorithm = new HMACSHA256())
            {
                var salt = algorithm.Key;
                var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
                return new(hash, salt);
            }
        }

        public static bool VerifyHash(String value, byte[] valueHash, byte[] valueSalt)
        {
            using (var algorithm = new HMACSHA256(valueSalt))
            {
                var computedHash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
                return CompareHashes(valueHash, computedHash);
            }
        }

        public static bool CompareHashes(byte[] originalHash, byte[] generatedHash)
        {
            for (int i = 0; i < generatedHash.Length; i++)
            {
                if (generatedHash[i] != originalHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
