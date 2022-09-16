using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.User
{
    public class UserDto : IDto
    {
        public Guid UserId { get; set; }
        public Guid UserRoleId { get; set; }
        public DateTime UserCreateDate { get; set; }
        public DateTime UserModifyDate { get; set; }
        public bool UserIsActive { get; set; }
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String UserEmail { get; set; }
        public String UserContactNumber { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public bool UserIsConfirmed { get; set; }

        public UserDto()
        {

        }

        public UserDto(
            Guid userRoleId, string userFirstName, string userLastName, 
            string userEmail, string userContactNumber, byte[] userPasswordHash, 
            byte[] userPasswordSalt, bool userIsConfirmed)
        {
            UserRoleId = userRoleId;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserContactNumber = userContactNumber;
            UserPasswordHash = userPasswordHash;
            UserPasswordSalt = userPasswordSalt;
            UserIsConfirmed = userIsConfirmed;
        }

        public UserDto(
            Guid userId, Guid userRoleId, DateTime userCreateDate,
            DateTime userModifyDate, bool userIsActive, string userFirstName, 
            string userLastName, string userEmail, string userContactNumber, 
            byte[] userPasswordHash, byte[] userPasswordSalt, 
            bool userIsConfirmed)
        {
            UserId = userId;
            UserRoleId = userRoleId;
            UserCreateDate = userCreateDate;
            UserModifyDate = userModifyDate;
            UserIsActive = userIsActive;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserContactNumber = userContactNumber;
            UserPasswordHash = userPasswordHash;
            UserPasswordSalt = userPasswordSalt;
            UserIsConfirmed = userIsConfirmed;
        }
    }
}
