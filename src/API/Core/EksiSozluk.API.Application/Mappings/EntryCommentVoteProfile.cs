using AutoMapper;
using EksiSozluk.API.Application.Dtos.EntryComment;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateVote;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class EntryCommentVoteProfile : Profile
    {
        public EntryCommentVoteProfile()
        {
            this.CreateMap<CreateEntryCommentVoteCommandRequest, EntryCommentVote>()
                .ForMember(ecf => ecf.EntryCommentId, r => r.MapFrom(r => r.EntryCommentId))
                .ForMember(ecf => ecf.UserId, r => r.MapFrom(r => r.UserId))
                .ForMember(ecf => ecf.VoteType, r => r.MapFrom(r => r.VoteType))
                .ReverseMap();

            this.CreateMap<EntryCommentVoteDto, EntryCommentVote>()
                .ForMember(ecf => ecf.Id, r => r.MapFrom(r => r.EntryCommentVoteId))
                .ForMember(ecf => ecf.CreateDate, r => r.MapFrom(r => r.EntryCommentVoteCreateDate))
                .ForMember(ecf => ecf.ModifyDate, r => r.MapFrom(r => r.EntryCommentVoteModifyDate))
                .ForMember(ecf => ecf.IsActive, r => r.MapFrom(r => r.EntryCommentVoteIsActive))
                .ForMember(ecf => ecf.EntryCommentId, r => r.MapFrom(r => r.EntryCommentId))
                .ForMember(ecf => ecf.UserId, r => r.MapFrom(r => r.UserId))
                .ForMember(ecf => ecf.VoteType, r => r.MapFrom(r => r.VoteType))
                .ReverseMap();
        }
    }
}
