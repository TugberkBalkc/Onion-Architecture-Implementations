using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetTodaysEntries
{
    public class GetTodaysEntriesQueryHandler : IRequestHandler<GetTodaysEntriesQueryRequest, GetTodaysEntriesQueryResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetTodaysEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<GetTodaysEntriesQueryResponse> Handle(GetTodaysEntriesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();

                query = query
                    .Where(i => i.CreateDate >= DateTime.Now.Date)
                    .Where(i => i.CreateDate <= DateTime.Now.AddDays(1).Date);

            query = query.Include(i => i.EntryComments)
                .OrderBy(i => Guid.NewGuid())
                .Take(request.Count);


            var getEntryDtos = await query.ProjectTo<GetEntryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GetTodaysEntriesQueryResponse()
            {
                Response = new SuccessfulDataBearerServiceResponse<List<GetEntryDto>>
                (title: ServerTitles.Successful, message: ServerMessages.EntriesRecieved, data: getEntryDtos, devNote: "")
            };
        }
    }
}
