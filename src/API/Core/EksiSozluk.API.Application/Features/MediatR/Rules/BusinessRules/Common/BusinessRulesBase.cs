using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions.BusinessLogic;
using EksiSozluk.API.Application.Exceptions.InternalServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules.Common
{
    public abstract class BusinessRulesBase
    {
        public async Task NullCheck<T>(T entity, String entityName)
        {
            if (entity is null)
                throw new BusinessLogicException(ServerTitles.Error, $"{entityName} {BusinessConstants.NotFound}");
        }

        public async Task ExistsCheck<T>(T entity, String entityName)
        {
            if (entity is not null)
                throw new BusinessLogicException(ServerTitles.Error, $"{entityName} {BusinessConstants.AlreadyExists}");
        }

        public async Task ActionOnAffectedRowsExists(int rows, Action action)
        {
            if (rows > 0)
            {
                action.Invoke();
            }
            else
            {
                throw new InternalServerException(ServerTitles.Error, ServerMessages.SomethingWentWrong);
            }
        }
    }
}
