using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Utilities.Responses.Common;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.API.Application.Utilities.Responses.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Logic
{
    public static class LogicEngine
    {
        public static IResponse Run(params IResponse[] logics)
        {
            foreach (var logic in logics)
            {
                if(logic.Success is false)
                {
                    //throw new BusinessLogicException(logic.Message, logic.Title);
                }
            }

            return null;
        }
    }
}
