using AutoMapper;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Update;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            this.CreateMap<CreateEntryCommandRequest, Entry>()
              .ForMember(e => e.UserId, r => r.MapFrom(r => r.UserId))
              .ForMember(e => e.Subject, r => r.MapFrom(r => r.EntrySubject))
              .ForMember(e => e.Content, r => r.MapFrom(r => r.EntryContent))
              .ReverseMap();

            this.CreateMap<UpdateEntryCommandRequest, Entry>()
            .ForMember(e=>e.Id, r=>r.MapFrom(r=>r.EntryId))
            .ForMember(e => e.Subject, r => r.MapFrom(r => r.EntrySubject))
            .ForMember(e => e.Content, r => r.MapFrom(r => r.EntryContent))
            .ReverseMap();

            this.CreateMap<Entry, EntryDto>()
                .ForMember(d => d.EntryId, e => e.MapFrom(e => e.Id))
                .ForMember(d => d.UserId, e => e.MapFrom(e => e.UserId))
                .ForMember(d => d.EntryCreateDate, e => e.MapFrom(e => e.CreateDate))
                .ForMember(d => d.EntryModifyDate, e => e.MapFrom(e => e.ModifyDate))
                .ForMember(d => d.EntryIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(d => d.EntrySubject, e => e.MapFrom(e => e.Subject))
                .ForMember(d => d.EntryContent, e => e.MapFrom(e => e.Content))
                .ReverseMap();

            this.CreateMap<GetEntryDto, Entry>()
           .ForMember(e => e.Id, r => r.MapFrom(r => r.EntryId))
           .ForMember(e => e.CreateDate, r => r.MapFrom(r => r.EntryCreateDate))
           .ForMember(e => e.ModifyDate, r => r.MapFrom(r => r.EntryModifyDate))
           .ForMember(e => e.IsActive, r => r.MapFrom(r => r.EntryIsActive))
           .ForMember(e => e.Subject, r => r.MapFrom(r => r.EntrySubject))
           .ForMember(e => e.Content, r => r.MapFrom(r => r.EntryContent))
           .ReverseMap();

        }
    }
}
