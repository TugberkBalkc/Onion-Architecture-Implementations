using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllUsersWithCount
{
    public class GetAllUsersWithCountQueryRequest : QueryRequestBase, IRequest<GetAllUsersWithCountQueryResponse>
    { 
    }
}
