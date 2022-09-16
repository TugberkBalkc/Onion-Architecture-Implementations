using AutoMapper;
using EksiSozluk.API.Application.Dtos.EntryComment;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Update;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class EntryCommentProfile : Profile
    {
        public EntryCommentProfile()
        {
            this.CreateMap<CreateEntryCommentCommandRequest, EntryComment>()
                .ForMember(ec => ec.EntryId, r => r.MapFrom(r => r.EntryId))
                .ForMember(ec => ec.UserId, r => r.MapFrom(r => r.UserId))
                .ForMember(ec => ec.Content, r => r.MapFrom(r => r.EntryCommentContent))
                .ReverseMap();

            this.CreateMap<UpdateEntryCommentCommandRequest, EntryComment>()
             .ForMember(ec => ec.EntryId, r => r.MapFrom(r => r.EntryId))
             .ForMember(ec => ec.UserId, r => r.MapFrom(r => r.UserId))
             .ForMember(ec => ec.Content, r => r.MapFrom(r => r.EntryCommentContent))
             .ReverseMap();

            this.CreateMap<EntryCommentDto, EntryComment>()
                .ForMember(ec => ec.Id, r => r.MapFrom(r => r.EntryCommentId))
                .ForMember(ec => ec.CreateDate, r => r.MapFrom(r => r.EntryCommentCreateDate))
                .ForMember(ec => ec.ModifyDate, r => r.MapFrom(r => r.EntryCommentModifyDate))
                .ForMember(ec => ec.IsActive, r => r.MapFrom(r => r.EntryCommentIsActive))
                .ForMember(ec => ec.EntryId, r => r.MapFrom(r => r.EntryId))
                .ForMember(ec => ec.UserId, r => r.MapFrom(r => r.UserId))
                .ForMember(ec => ec.Content, r => r.MapFrom(r => r.EntryCommentContent))
                .ReverseMap();
        } 
    }
}
