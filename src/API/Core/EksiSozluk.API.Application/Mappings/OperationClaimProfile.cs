using AutoMapper;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Update;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {
            this.CreateMap<CreateOperationClaimCommandRequest, OperationClaim>()
             .ForMember(opc => opc.Name, r => r.MapFrom(r => r.OperationClaimName))
             .ReverseMap();

            this.CreateMap<UpdateOperationClaimCommandRequest, OperationClaim>()
             .ForMember(opc => opc.Name, r => r.MapFrom(r => r.OperationClaimName))
             .ReverseMap();

            this.CreateMap<OperationClaim, OperationClaimDto>()
                .ForMember(d => d.OperationClaimId, opc => opc.MapFrom(opc => opc.Id))
                .ForMember(d => d.OperationClaimCreateDate, opc => opc.MapFrom(opc => opc.CreateDate))
                .ForMember(d => d.OperationClaimModifyDate, opc => opc.MapFrom(opc => opc.ModifyDate))
                .ForMember(d => d.OperationClaimIsActive, opc => opc.MapFrom(opc => opc.IsActive))
                .ForMember(d => d.OperationClaimName, opc => opc.MapFrom(opc => opc.Name))
                .ReverseMap();

         
        }
    }
}
