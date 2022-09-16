using AutoMapper;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Features.MediatR.Commands.Role.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.Role.Update;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            this.CreateMap<CreateRoleCommandRequest, Role>()
                .ForMember(r => r.Name, cr => cr.MapFrom(cr => cr.RoleName))
                .ReverseMap();

            this.CreateMap<UpdateRoleCommandRequest, Role>()
              .ForMember(r => r.Name, cr => cr.MapFrom(cr => cr.RoleName))
              .ReverseMap();

            this.CreateMap<RoleDto, Role>()
                .ForMember(r => r.Id, d => d.MapFrom(d => d.RoleId))
                .ForMember(r => r.CreateDate, d => d.MapFrom(d => d.RoleCreateDate))
                .ForMember(r => r.ModifyDate, d => d.MapFrom(d => d.RoleModifyDate))
                .ForMember(r => r.IsActive, d => d.MapFrom(d => d.RoleIsActive))
                .ForMember(r => r.Name, d => d.MapFrom(d => d.RoleName))
                .ReverseMap();
        }
    }
}
