using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions.BusinessLogic;
using EksiSozluk.API.Application.Exceptions.InternalServer;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules.Common;
using EksiSozluk.API.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules
{
    public class UserBusinessRules : BusinessRulesBase
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckIfEmailChanged(String oldEmailAddress, String newEmailAddress)
        {
            return String.CompareOrdinal(oldEmailAddress, newEmailAddress) != 0;
        }

        public async Task CheckIfUserConfirmed(bool isConfirmed)
        {
            if (isConfirmed is true)
                throw new BusinessLogicException(ServerTitles.Error, ServerMessages.UserEmailAlreadyConfirmed);
        }

        public async Task DecideHashesMatched(bool hashResult)
        {
            if (hashResult is not true)
                throw new BusinessLogicException(ServerMessages.WrongOldPassword, ServerTitles.Error);
        }
    }
}
