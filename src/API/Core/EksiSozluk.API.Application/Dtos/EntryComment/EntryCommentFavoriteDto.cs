using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.EntryComment
{
    public class EntryCommentFavoriteDto : IDto
    {
        public Guid EntryCommentFavoriteId { get; set; }
        public DateTime EntryCommentFavoriteCreateDate { get; set; }
        public DateTime EntryCommentFavoriteModifyDate { get; set; }
        public bool EntryCommentFavoriteIsActive { get; set; }
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }

        public EntryCommentFavoriteDto()
        {

        }

        public EntryCommentFavoriteDto(Guid entryCommentId, Guid userId)
        {
            EntryCommentId = entryCommentId;
            UserId = userId;
        }

        public EntryCommentFavoriteDto(
            Guid entryCommentFavoriteId, DateTime entryCommentFavoriteCreateDate, DateTime entryCommentFavoriteModifyDate, 
            bool entryCommentFavoriteIsActive, Guid entryCommentId, Guid userId)
        {
            EntryCommentFavoriteId = entryCommentFavoriteId;
            EntryCommentFavoriteCreateDate = entryCommentFavoriteCreateDate;
            EntryCommentFavoriteModifyDate = entryCommentFavoriteModifyDate;
            EntryCommentFavoriteIsActive = entryCommentFavoriteIsActive;
            EntryCommentId = entryCommentId;
            UserId = userId;
        }
    }
}
