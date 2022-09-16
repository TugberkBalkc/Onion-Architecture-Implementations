using AutoMapper;
using EksiSozluk.API.Application.Dtos.EntryComment;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateFavorite;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class EntryCommentFavoriteProfile : Profile
    {
        public EntryCommentFavoriteProfile()
        {
            this.CreateMap<CreateEntryCommentFavoriteCommandRequest, EntryCommentFavorite>()
                .ForMember(ecf => ecf.EntryCommentId, r => r.MapFrom(r => r.EntryCommentId))
                .ForMember(ecf => ecf.UserId, r => r.MapFrom(r => r.UserId))
                .ReverseMap();

            this.CreateMap<EntryCommentFavoriteDto, EntryCommentFavorite>()
                .ForMember(ecf => ecf.Id, r => r.MapFrom(r => r.EntryCommentFavoriteId))
                .ForMember(ecf => ecf.CreateDate, r => r.MapFrom(r => r.EntryCommentFavoriteCreateDate))
                .ForMember(ecf => ecf.ModifyDate, r => r.MapFrom(r => r.EntryCommentFavoriteModifyDate))
                .ForMember(ecf => ecf.IsActive, r => r.MapFrom(r => r.EntryCommentFavoriteIsActive))
                .ForMember(ecf => ecf.EntryCommentId, r => r.MapFrom(r => r.EntryCommentId))
                .ForMember(ecf => ecf.UserId, r => r.MapFrom(r => r.UserId))
                .ReverseMap();
        }
    }
}
