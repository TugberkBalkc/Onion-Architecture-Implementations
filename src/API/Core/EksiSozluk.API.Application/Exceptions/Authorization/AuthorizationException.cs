using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Exceptions.Authorization
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string title, string message, string userName) : base(title + "," + message + "," + userName)
        {
        }
    }
}
