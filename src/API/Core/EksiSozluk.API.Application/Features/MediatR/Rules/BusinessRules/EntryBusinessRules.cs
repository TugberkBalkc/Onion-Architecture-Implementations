using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions.BusinessLogic;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules.Common;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.Common;
using EksiSozluk.API.Application.Utilities.Responses.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules
{
    public class EntryBusinessRules : BusinessRulesBase
    {
        private readonly IEntryRepository _entryRepository;

        public EntryBusinessRules(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

     
    }
}
