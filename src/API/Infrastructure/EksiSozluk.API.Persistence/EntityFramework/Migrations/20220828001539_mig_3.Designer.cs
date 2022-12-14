// <auto-generated />
using System;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EksiSozluk.API.Persistence.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220828001539_mig_3")]
    partial class mig_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EmailConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<string>("NewEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("NewEmail");

                    b.Property<string>("OldEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("OldEmail");

                    b.HasKey("Id");

                    b.ToTable("EmailConfirmations");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Subject");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EntryId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryComments");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryCommentFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EntryCommentId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EntryCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryCommentFavorites");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryCommentVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EntryCommentId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<int>("VoteType")
                        .HasColumnType("int")
                        .HasColumnName("VoteType");

                    b.HasKey("Id");

                    b.HasIndex("EntryCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryCommentVotes");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EntryId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryFavorites");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EntryId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<int>("VoteType")
                        .HasColumnType("int")
                        .HasColumnName("VoteType");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryVotes");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.OperationClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("ContactNumber");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("IsConfirmed");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("LastName");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("ModifyDate");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)")
                        .HasColumnName("PasswordSalt");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OperationClaimRole", b =>
                {
                    b.Property<Guid>("OperationClaimsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OperationClaimsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("OperationClaimRole");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.Entry", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.User", "User")
                        .WithMany("Entries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryComment", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.Entry", "Entry")
                        .WithMany("EntryComments")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EksiSozluk.API.Domain.Entities.User", "User")
                        .WithMany("EntryComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryCommentFavorite", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.EntryComment", "EntryComment")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EksiSozluk.API.Domain.Entities.User", "User")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EntryComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryCommentVote", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.EntryComment", "EntryComment")
                        .WithMany("EntryCommentVotes")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EksiSozluk.API.Domain.Entities.User", "User")
                        .WithMany("EntryCommentVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EntryComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryFavorite", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.Entry", "Entry")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EksiSozluk.API.Domain.Entities.User", "User")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryVote", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.Entry", "Entry")
                        .WithMany("EntryVotes")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EksiSozluk.API.Domain.Entities.User", "User")
                        .WithMany("EntryVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.User", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OperationClaimRole", b =>
                {
                    b.HasOne("EksiSozluk.API.Domain.Entities.OperationClaim", null)
                        .WithMany()
                        .HasForeignKey("OperationClaimsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EksiSozluk.API.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.Entry", b =>
                {
                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.EntryComment", b =>
                {
                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryCommentVotes");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EksiSozluk.API.Domain.Entities.User", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryCommentVotes");

                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });
#pragma warning restore 612, 618
        }
    }
}
