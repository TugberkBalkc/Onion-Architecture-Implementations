using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesActive
{
    public class GetAllEntriesActiveQueryHandler : IRequestHandler<GetAllEntriesActiveQueryRequest, GetAllEntriesActiveQueryResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetAllEntriesActiveQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<GetAllEntriesActiveQueryResponse> Handle(GetAllEntriesActiveQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();

            query = query.Where(e => e.IsActive == true);

            query = query.Take(request.Count);

            var getEntryDtos = await query.ProjectTo<GetEntryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GetAllEntriesActiveQueryResponse()
            {
                Response = new SuccessfulDataBearerServiceResponse<List<GetEntryDto>>
                (title: ServerTitles.Successful, message: ServerMessages.EntriesRecieved, data: getEntryDtos, devNote: "")
            };
        }
    }
}
