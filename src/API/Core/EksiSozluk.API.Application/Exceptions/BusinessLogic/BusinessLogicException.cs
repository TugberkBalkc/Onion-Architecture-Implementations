using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Exceptions.BusinessLogic
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string title, string message) : base(title + "," + message)
        {
        }
    }
}
