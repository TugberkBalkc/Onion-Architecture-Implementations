using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.User
{
    public class RoleDto : IDto
    {
        public Guid RoleId { get; set; }
        public DateTime RoleCreateDate { get; set; }
        public DateTime RoleModifyDate { get; set; }
        public bool RoleIsActive { get; set; }
        public String RoleName { get; set; }

        public RoleDto()
        {

        }

        public RoleDto(
            Guid roleId, DateTime roleCreateDate, DateTime roleModifyDate, 
            bool roleIsActive, string roleName)
        {
            RoleId = roleId;
            RoleCreateDate = roleCreateDate;
            RoleModifyDate = roleModifyDate;
            RoleIsActive = roleIsActive;
            RoleName = roleName;
        }
    }
}
