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
    public class EntryEntityConfiguration : BaseEntityConfiguration<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Subject)
                .HasColumnName("Subject")
                .HasColumnType("nvarchar(500)");

            builder.Property(e => e.Content)
               .HasColumnName("Content")
               .HasColumnType("nvarchar(MAX)");


            builder
                .HasOne(e => e.User)
                .WithMany(u => u.Entries)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
