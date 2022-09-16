using AutoMapper;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.AddFavorite;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class EntryFavoriteProfile : Profile
    {
        public EntryFavoriteProfile()
        {
            this.CreateMap<CreateEntryFavoriteCommandRequest, EntryFavorite>()
                .ForMember(ef => ef.EntryId, r => r.MapFrom(r => r.EntryId))
                .ForMember(ef => ef.UserId, r => r.MapFrom(r => r.UserId))
                .ReverseMap();

            this.CreateMap<EntryFavoriteDto, EntryFavorite>()
               .ForMember(ef => ef.Id, r => r.MapFrom(r => r.EntryFavoriteId))
               .ForMember(ef => ef.CreateDate, r => r.MapFrom(r => r.EntryFavoriteCreateDate))
               .ForMember(ef => ef.ModifyDate, r => r.MapFrom(r => r.EntryFavoriteModifyDate))
               .ForMember(ef => ef.IsActive, r => r.MapFrom(r => r.EntryFavoriteIsActive))
               .ForMember(ef => ef.EntryId, r => r.MapFrom(r => r.EntryId))
               .ForMember(ef => ef.UserId, r => r.MapFrom(r => r.UserId))
               .ReverseMap();
        }
    }
}
