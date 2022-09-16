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
    public class RoleOperationClaimEntityConfiguration : BaseEntityConfiguration<RoleOperationClaim>
    {
        public override void Configure(EntityTypeBuilder<RoleOperationClaim> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.RoleId)
              .HasColumnName("RoleId")
              .HasColumnType("uniqueidentifier");

            builder.Property(r => r.OperationClaimId)
                .HasColumnName("OperationClaimId")
                .HasColumnType("uniqueidentifier");

            builder.HasOne(r => r.Role)
                .WithMany(r => r.RoleOperationClaims)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.OperationClaim)
             .WithMany(r => r.RoleOperationClaims)
             .HasForeignKey(r => r.OperationClaimId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
