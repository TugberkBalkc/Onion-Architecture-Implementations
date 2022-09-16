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
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier");

            builder.Property(u => u.FirstName)
                .HasColumnName("FirstName")
               .HasColumnType("nvarchar(MAX)");

            builder.Property(u => u.LastName)
                .HasColumnName("LastName")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(u => u.ContactNumber)
                .HasColumnName("ContactNumber")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(u => u.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("varbinary(MAX)");

            builder.Property(u => u.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasColumnType("varbinary(MAX)");

            builder.Property(r => r.IsConfirmed)
                .HasColumnName("IsConfirmed")
                .HasColumnType("bit");


            builder
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
