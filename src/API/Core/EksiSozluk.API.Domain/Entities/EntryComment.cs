using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Domain.Entities
{
    public class EntryComment : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }

        public String Content { get; set; }


        public virtual User User { get; set; }
        public virtual Entry Entry { get; set; }

        public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public virtual ICollection<EntryCommentVote> EntryCommentVotes { get; set; }
    }
}
