using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Domain.Entities;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfEmailConfirmationRepository : EfRepositoryBase<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EfEmailConfirmationRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
