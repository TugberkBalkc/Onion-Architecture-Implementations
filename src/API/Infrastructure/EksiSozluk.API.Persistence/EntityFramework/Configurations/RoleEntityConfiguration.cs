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
    public class RoleEntityConfiguration : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);



            builder.Property(r => r.Name)
           .HasColumnName("Name")
           .HasColumnType("nvarchar(MAX)");

        }
    }
}
