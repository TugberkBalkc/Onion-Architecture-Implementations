using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Exceptions.InternalServer
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string title, string message) : base(title + "," + message)
        {
        }
    }
}
