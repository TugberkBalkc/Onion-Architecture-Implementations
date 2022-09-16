using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Shared.Events.EntryComment
{
    public class DeleteEntryCommentFavoriteEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
