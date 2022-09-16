using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.EntryComment
{
    public class EntryCommentDto : IDto
    {
        public Guid EntryCommentId { get; set; }
        public DateTime EntryCommentCreateDate { get; set; }
        public DateTime EntryCommentModifyDate { get; set; }
        public bool EntryCommentIsActive { get; set; }
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }

        public String EntryCommentContent { get; set; }

        public EntryCommentDto()
        {

        }

        public EntryCommentDto(Guid userId, Guid entryId, string entryCommentContent)
        {
            UserId = userId;
            EntryId = entryId;
            EntryCommentContent = entryCommentContent;
        }

        public EntryCommentDto(
            Guid entryCommentId, DateTime entryCommentCreateDate, DateTime entryCommentModifyDate, 
            bool entryCommentIsActive, Guid userId, Guid entryId)
        {
            EntryCommentId = entryCommentId;
            EntryCommentCreateDate = entryCommentCreateDate;
            EntryCommentModifyDate = entryCommentModifyDate;
            EntryCommentIsActive = entryCommentIsActive;
            UserId = userId;
            EntryId = entryId;
        }
    }
}
