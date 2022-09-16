using AutoMapper;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Features.MediatR.Commands.Role.AddClaim;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class RoleOperationClaimProfile : Profile
    {
        public RoleOperationClaimProfile()
        {
            this.CreateMap<CreateRoleClaimCommandRequest, RoleOperationClaim>()
                .ForMember(ropc => ropc.RoleId, r => r.MapFrom(r => r.RoleId))
                .ForMember(ropc => ropc.OperationClaimId, r => r.MapFrom(r => r.OperationClaimId))
                .ReverseMap();

            this.CreateMap<RoleOperationClaimDto, RoleOperationClaim>()
                .ForMember(ropc => ropc.Id, ropcd => ropcd.MapFrom(ropc => ropc.RoleOperationClaimId))
                .ForMember(ropc => ropc.CreateDate, ropcd => ropcd.MapFrom(ropc => ropc.RoleOperationClaimCreateDate))
                .ForMember(ropc => ropc.ModifyDate, ropcd => ropcd.MapFrom(ropc => ropc.RoleOperationClaimModifyDate))
                .ForMember(ropc => ropc.IsActive, ropcd => ropcd.MapFrom(ropc => ropc.RoleOperationClaimIsActive))
                .ForMember(ropc => ropc.RoleId, ropcd => ropcd.MapFrom(ropc => ropc.RoleId))
                .ForMember(ropc => ropc.OperationClaimId, ropcd => ropcd.MapFrom(ropc => ropc.OperationClaimId))
                .ReverseMap();
        }
    }
}
