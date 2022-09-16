using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesByContent
{
    public class GetAllEntriesByContentQueryHandler : IRequestHandler<GetAllEntriesByContentQueryRequest, GetAllEntriesByContentQueryResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetAllEntriesByContentQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<GetAllEntriesByContentQueryResponse> Handle(GetAllEntriesByContentQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();

            query = query.Where(e => e.Subject.Trim().ToLower().Contains(request.EntryContent.Trim().ToLower()));

            query = query.Take(request.Count);

            var getEntryDtos = await query.ProjectTo<GetEntryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GetAllEntriesByContentQueryResponse()
            {
                Response = new SuccessfulDataBearerServiceResponse<List<GetEntryDto>>
                (title: ServerTitles.Successful, message: ServerMessages.EntriesRecieved, data: getEntryDtos, devNote: "")
            };
        }
    }
}
