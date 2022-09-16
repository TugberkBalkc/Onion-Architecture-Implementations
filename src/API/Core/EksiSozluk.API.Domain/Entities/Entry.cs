using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Domain.Entities
{
    public class Entry : BaseEntity
    {
        public Guid UserId { get; set; }

        public String Subject { get; set; }
        public String Content { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<EntryFavorite> EntryFavorites { get; set; }
        public virtual ICollection<EntryVote> EntryVotes { get; set; }

        public virtual ICollection<EntryComment> EntryComments { get; set; }
    }
}
