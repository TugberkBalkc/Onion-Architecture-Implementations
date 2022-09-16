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
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.Property(ec => ec.EntryCommentId)
                .HasColumnName("EntryCommentId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ecf => ecf.UserId)
               .HasColumnName("UserId")
               .HasColumnType("uniqueidentifier");


            builder
               .HasOne(ecf => ecf.EntryComment)
               .WithMany(ec => ec.EntryCommentFavorites)
               .HasForeignKey(ecf => ecf.EntryCommentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(ecf => ecf.User)
            .WithMany(u => u.EntryCommentFavorites)
            .HasForeignKey(ecf => ecf.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
