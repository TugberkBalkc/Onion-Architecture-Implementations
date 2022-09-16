using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Interfaces.Repositories.Common
{
    public interface IRepository<T> : IAsyncRepository<T> , ISyncRepository<T>
        where T : BaseEntity
    {
    }
}
