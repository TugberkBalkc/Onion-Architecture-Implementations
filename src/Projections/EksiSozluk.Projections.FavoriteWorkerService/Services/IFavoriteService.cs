using EksiSozluk.Shared.Events.Entry;
using EksiSozluk.Shared.Events.EntryComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Projections.FavoriteWorkerService.Services
{
    public interface IFavoriteService
    {
        Task CreateEntryFavorite(CreateEntryFavoriteEvent createEntryFavoriteEvent);
        Task DeleteEntryFavorite(DeleteEntryFavoriteEvent deleteEntryFavoriteEvent);

        Task CreateEntryCommentFavorite(CreateEntryCommentFavoriteEvent createEntryCommentFavoriteEvent);
        Task DeleteEntryCommentFavorite(DeleteEntryCommentFavoriteEvent deleteEntryCommentFavoriteEvent);
    }
}
