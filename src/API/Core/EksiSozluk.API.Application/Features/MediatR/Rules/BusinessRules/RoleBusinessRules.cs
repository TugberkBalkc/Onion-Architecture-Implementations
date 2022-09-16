using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules.Common;
using EksiSozluk.API.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules
{
    public class RoleBusinessRules : BusinessRulesBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public RoleBusinessRules(IRoleRepository roleRepository, IOperationClaimRepository operationClaimRepository)
        {
            _roleRepository = roleRepository;
            _operationClaimRepository = operationClaimRepository;
        }
    }
}
