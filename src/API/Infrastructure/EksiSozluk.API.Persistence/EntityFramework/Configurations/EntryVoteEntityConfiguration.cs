using EksiSozluk.API.Domain.Entities;
using EksiSozluk.API.Persistence.EntityFramework.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.EntityFramework.Configurations
{
    public class EntryVoteEntityConfiguration : BaseEntityConfiguration<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);

            builder.Property(ev => ev.EntryId)
                .HasColumnName("EntryId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ev => ev.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ev => ev.VoteType)
                .HasColumnName("VoteType");


            builder
                .HasOne(ev => ev.Entry)
                .WithMany(e => e.EntryVotes)
                .HasForeignKey(ev => ev.EntryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ev => ev.User)
                .WithMany(u => u.EntryVotes)
                .HasForeignKey(ev => ev.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
