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

namespace EksiSozluk.Projections.VoteWorkerService.Services
{
    public class VoteService : IVoteService
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;

        public VoteService(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionString = _configuration.GetConnectionString(WorkerServiceConstants.WorkerServiceConnectionStringKey);
        }

        public async Task CreateEntryCommentVote(CreateEntryCommentVoteEvent createEntryCommentVoteEvent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection
                    .ExecuteAsync("INSERT INTO EntryCommentVotes (Id, EntryCommentId, UserId, CreateDate, ModifyDate, IsActive) VALUES (@Id, @EntryCommentId, @UserId, @VoteType, @CreateDate, @ModifyDate, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        EntryId = createEntryCommentVoteEvent.EntryCommentId,
                        UserId = createEntryCommentVoteEvent.UserId,
                        VoteType = Convert.ToInt16(createEntryCommentVoteEvent.VoteType),
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        IsActive = true
                    });
            }
        }

        public async Task CreateEntryVote(CreateEntryVoteEvent createEntryVoteEvent)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection
                    .ExecuteAsync("INSERT INTO EntryVotes (Id, EntryCommentId, UserId, CreateDate, ModifyDate, IsActive) VALUES (@Id, @EntryId, @UserId, @VoteType, @CreateDate, @ModifyDate, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        EntryId = createEntryVoteEvent.EntryId,
                        UserId = createEntryVoteEvent.UserId,
                        VoteType = Convert.ToInt16(createEntryVoteEvent.VoteType),
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        IsActive = true
                    });
            }
        }

        public Task DeleteEntryCommentVote(DeleteEntryCommentVoteEvent deleteEntryCommentVoteEvent)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntryVote(DeleteEntryVoteEvent deleteEntryVoteEvent)
        {
            throw new NotImplementedException();
        }
    }
}
