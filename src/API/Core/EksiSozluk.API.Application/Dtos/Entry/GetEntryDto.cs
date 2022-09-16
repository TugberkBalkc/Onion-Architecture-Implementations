using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Entry
{
    public class GetEntryDto
    {
        public Guid EntryId { get; set; }
        public DateTime EntryCreateDate { get; set; }
        public DateTime EntryModifyDate { get; set; }
        public bool EntryIsActive { get; set; }
        public String EntrySubject { get; set; }
        public String EntryContent { get; set; }
    }
}
