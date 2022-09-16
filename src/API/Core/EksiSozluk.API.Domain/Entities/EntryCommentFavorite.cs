using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Domain.Entities
{
    public class EntryCommentFavorite : BaseEntity
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }


        public virtual EntryComment EntryComment { get; set; }
        public virtual User User { get; set; }

    }
}
