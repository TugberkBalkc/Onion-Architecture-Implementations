using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.User
{
    public class UserOnGetEntryDto
    {
        public Guid UserId { get; set; }
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
    }
}
