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
    public class EntryCommentEntityConfiguration : BaseEntityConfiguration<EntryComment>
    {
        public override void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            base.Configure(builder);

            builder.Property(ec => ec.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ec => ec.EntryId)
                .HasColumnName("EntryId")
                .HasColumnType("uniqueidentifier");

            builder.Property(ec => ec.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar(MAX)");


            builder
                .HasOne(ec => ec.User)
                .WithMany(u => u.EntryComments)
                .HasForeignKey(ec => ec.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(ec => ec.Entry)
               .WithMany(e => e.EntryComments)
               .HasForeignKey(ec => ec.EntryId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
