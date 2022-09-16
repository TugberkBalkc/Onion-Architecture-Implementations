using AutoMapper;
using EksiSozluk.API.Application.Dtos.Security;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.Update;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<CreateUserCommandRequest, User>()
                .ForMember(u => u.RoleId, r => r.MapFrom(r => r.UserRoleId))
                .ForMember(u => u.FirstName, r => r.MapFrom(r => r.UserFirstName))
                .ForMember(u => u.LastName, r => r.MapFrom(r => r.UserLastName))
                .ForMember(u => u.Email, r => r.MapFrom(r => r.UserEmail))
                .ForMember(u => u.ContactNumber, r => r.MapFrom(r => r.UserContactNumber))
                .ReverseMap();


            this.CreateMap <UpdateUserCommandRequest, User>()
                .ForMember(u => u.FirstName, r => r.MapFrom(r => r.UserFirstName))
                .ForMember(u => u.LastName, r => r.MapFrom(r => r.UserLastName))
                .ForMember(u => u.Email, r => r.MapFrom(r => r.UserEmail))
                .ForMember(u => u.ContactNumber, r => r.MapFrom(r => r.UserContactNumber))
                .ReverseMap();

            this.CreateMap<User, UserDto>()
                .ForMember(d => d.UserId, u => u.MapFrom(u => u.Id))
                .ForMember(d => d.UserRoleId, u => u.MapFrom(u => u.RoleId))
                .ForMember(d => d.UserCreateDate, u => u.MapFrom(u => u.CreateDate))
                .ForMember(d => d.UserModifyDate, u => u.MapFrom(u => u.ModifyDate))
                .ForMember(d => d.UserIsActive, u => u.MapFrom(u => u.IsActive))
                .ForMember(d => d.UserFirstName, u => u.MapFrom(u => u.FirstName))
                .ForMember(d => d.UserLastName, u => u.MapFrom(u => u.LastName))
                .ForMember(d => d.UserEmail, u => u.MapFrom(u => u.Email))
                .ForMember(d => d.UserContactNumber, u => u.MapFrom(u => u.ContactNumber))
                .ForMember(d => d.UserPasswordHash, u => u.MapFrom(u => u.PasswordHash))
                .ForMember(d => d.UserPasswordSalt, u => u.MapFrom(u => u.PasswordSalt))
                .ForMember(d => d.UserIsConfirmed, u => u.MapFrom(u => u.IsConfirmed))
                .ReverseMap();

        }
    }
}
