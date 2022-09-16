using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Entry
{
    public class EntryFavoriteDto : IDto
    {
        public Guid EntryFavoriteId { get; set; }
        public DateTime EntryFavoriteCreateDate { get; set; }
        public DateTime EntryFavoriteModifyDate { get; set; }
        public bool EntryFavoriteIsActive { get; set; }
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }

        public EntryFavoriteDto()
        {

        }

        public EntryFavoriteDto(Guid entryId, Guid userId)
        {
            EntryId = entryId;
            UserId = userId;
        }

        public EntryFavoriteDto(
            Guid entryFavoriteId, DateTime entryFavoriteCreateDate, DateTime entryFavoriteModifyDate,
            bool entryFavoriteIsActive, Guid entryId, Guid userId)
        {
            EntryFavoriteId = entryFavoriteId;
            EntryFavoriteCreateDate = entryFavoriteCreateDate;
            EntryFavoriteModifyDate = entryFavoriteModifyDate;
            EntryFavoriteIsActive = entryFavoriteIsActive;
            EntryId = entryId;
            UserId = userId;
        }
    }
}
