using EksiSozluk.API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.EntityFramework.Configurations.Common
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(be => be.Id);

            builder.Property(be => be.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(be => be.CreateDate)
                .ValueGeneratedOnAdd()
                .HasColumnName("CreateDate")
                .HasColumnType("datetime");

            builder.Property(be => be.ModifyDate)
                .ValueGeneratedOnAdd()
                .HasColumnName("ModifyDate")
                .HasColumnType("datetime");

            builder.Property(be => be.IsActive)
                .ValueGeneratedOnAdd()
                .HasColumnName("IsActive")
                .HasColumnType("bit");

        }
    }
}
