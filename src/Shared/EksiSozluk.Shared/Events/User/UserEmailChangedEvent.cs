using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Shared.Events.User
{
    public class UserEmailChangedEvent
    {
        public String OldEmailAddress { get; set; }
        public String NewEmailAddress { get; set; }

    }
}
