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
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.Property(ef => ef.EntryId)
                .HasColumnName("EntryId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ef => ef.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");


            builder
                .HasOne(ef => ef.Entry)
                .WithMany(e => e.EntryFavorites)
                .HasForeignKey(ef => ef.EntryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasOne(ef => ef.User)
                .WithMany(u => u.EntryFavorites)
                .HasForeignKey(ef => ef.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
