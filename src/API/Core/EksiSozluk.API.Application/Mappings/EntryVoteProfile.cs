using AutoMapper;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.CreateVote;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class EntryVoteProfile : Profile
    {
        public EntryVoteProfile()
        {
            this.CreateMap<CreateEntryVoteCommandRequest, EntryVote>()
              .ForMember(ef => ef.EntryId, r => r.MapFrom(r => r.EntryId))
              .ForMember(ef => ef.UserId, r => r.MapFrom(r => r.UserId))
              .ForMember(ef => ef.VoteType, r => r.MapFrom(r => r.VoteType))
              .ReverseMap();

            this.CreateMap<EntryVoteDto, EntryVote>()
               .ForMember(ef => ef.Id, r => r.MapFrom(r => r.EntryVoteId))
               .ForMember(ef => ef.CreateDate, r => r.MapFrom(r => r.EntryVoteCreateDate))
               .ForMember(ef => ef.ModifyDate, r => r.MapFrom(r => r.EntryVoteModifyDate))
               .ForMember(ef => ef.IsActive, r => r.MapFrom(r => r.EntryVoteIsActive))
               .ForMember(ef => ef.EntryId, r => r.MapFrom(r => r.EntryId))
               .ForMember(ef => ef.UserId, r => r.MapFrom(r => r.UserId))
               .ForMember(ef => ef.VoteType, r => r.MapFrom(r => r.VoteType))
               .ReverseMap();

            this.CreateMap<EntryVoteOnGetEntryDto, EntryVote>()
             .ForMember(ef => ef.EntryId, r => r.MapFrom(r => r.EntryId))
             .ForMember(ef => ef.UserId, r => r.MapFrom(r => r.UserId))
             .ForMember(ef => ef.VoteType, r => r.MapFrom(r => r.VoteType))
             .ReverseMap();
        }
    }
}
