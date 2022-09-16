using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid RoleId { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String ContactNumber{ get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsConfirmed { get; set; }


        public virtual Role Role { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
        public virtual ICollection<EntryFavorite> EntryFavorites { get; set; }
        public virtual ICollection<EntryVote> EntryVotes { get; set; }

        public virtual ICollection<EntryComment> EntryComments { get; set; }
        public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public virtual ICollection<EntryCommentVote> EntryCommentVotes { get; set; }
    }
}
