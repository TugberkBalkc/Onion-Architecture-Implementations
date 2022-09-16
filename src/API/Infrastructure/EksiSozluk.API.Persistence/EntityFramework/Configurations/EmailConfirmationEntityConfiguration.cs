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
    public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.Property(ec => ec.OldEmail)
             .HasColumnName("OldEmail")
             .HasColumnType("nvarchar(MAX)");

            builder.Property(ec => ec.NewEmail)
             .HasColumnName("NewEmail")
             .HasColumnType("nvarchar(MAX)");
        }
    }
}
