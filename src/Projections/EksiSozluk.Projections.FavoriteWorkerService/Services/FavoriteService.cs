using Dapper;
using EksiSozluk.Shared.Constants.WorkerServices;
using EksiSozluk.Shared.Events.Entry;
using EksiSozluk.Shared.Events.EntryComment;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Projections.FavoriteWorkerService.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;

        public FavoriteService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(WorkerServiceConstants.WorkerServiceConnectionStringKey);
        }

        public async Task CreateEntryCommentFavorite(CreateEntryCommentFavoriteEvent createEntryCommentFavoriteEvent)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                await connection
                    .ExecuteAsync("INSERT INTO EntryCommentFavorites (Id, EntryCommentId, UserId, CreateDate, ModifyDate, IsActive) VALUES (@Id, @EntryCommentId, @UserId, @CreateDate, @ModifyDate, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        EntryId = createEntryCommentFavoriteEvent.EntryCommentId,
                        UserId = createEntryCommentFavoriteEvent.UserId,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        IsActive = true
                    });
            }
        }

        public async Task CreateEntryFavorite(CreateEntryFavoriteEvent createEntryFavoriteEvent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection
                    .ExecuteAsync("INSERT INTO EntryFavorites (Id, EntryId, UserId, CreateDate, ModifyDate, IsActive) VALUES (@Id, @EntryId, @UserId, @CreateDate, @ModifyDate, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        EntryId = createEntryFavoriteEvent.EntryId,
                        UserId = createEntryFavoriteEvent.UserId,
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        IsActive = true
                    });
            }
        }

        public async Task DeleteEntryCommentFavorite(DeleteEntryCommentFavoriteEvent deleteEntryCommentFavoriteEvent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection
                    .ExecuteAsync("DELETE FROM EntryCommentFavorites WHERE EntryCommentId = @EntryCommentId AND UserId = @UserId",
                    new
                    {
                        EntryId = deleteEntryCommentFavoriteEvent.EntryCommentId,
                        UserId = deleteEntryCommentFavoriteEvent.UserId
                    });
            }
        }

        public async Task DeleteEntryFavorite(DeleteEntryFavoriteEvent deleteEntryFavoriteEvent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection
                    .ExecuteAsync("DELETE FROM EntryFavorites WHERE EntryId = @EntryCommentId AND UserId = @UserId",
                    new
                    {
                        EntryId = deleteEntryFavoriteEvent.EntryId,
                        UserId = deleteEntryFavoriteEvent.UserId
                    });
            }
        }
    }
}
