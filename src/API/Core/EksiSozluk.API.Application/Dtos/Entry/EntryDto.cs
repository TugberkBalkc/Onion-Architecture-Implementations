using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Entry
{
    public class EntryDto : IDto
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime EntryCreateDate { get; set; }
        public DateTime EntryModifyDate { get; set; }
        public bool EntryIsActive { get; set; }
        public String EntrySubject { get; set; }
        public String EntryContent { get; set; }
     
        public EntryDto()
        {

        }

        public EntryDto(Guid userId, string entrySubject, string entryContent)
        {
            UserId = userId;
            EntrySubject = entrySubject;
            EntryContent = entryContent;
        }

        public EntryDto(
            Guid entryId, Guid userId, DateTime entryCreateDate, 
            DateTime entryModifyDate, bool entryIsActive, string entrySubject, 
            string entryContent)
        {
            EntryId = entryId;
            UserId = userId;
            EntryCreateDate = entryCreateDate;
            EntryModifyDate = entryModifyDate;
            EntryIsActive = entryIsActive;
            EntrySubject = entrySubject;
            EntryContent = entryContent;
        }
    }
}
