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
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.Property(ecv => ecv.EntryCommentId)
                .HasColumnName("EntryCommentId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ecv => ecv.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ecv => ecv.VoteType)
                .HasColumnName("VoteType");

            builder
                .HasOne(ecv => ecv.EntryComment)
                .WithMany(ec => ec.EntryCommentVotes)
                .HasForeignKey(ecv => ecv.EntryCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ecv => ecv.User)
                .WithMany(u => u.EntryCommentVotes)
                .HasForeignKey(ecv => ecv.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
