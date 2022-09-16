using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Exceptions.Database
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string title, string message) : base(title + "," + message)
        {
        }
    }
}
