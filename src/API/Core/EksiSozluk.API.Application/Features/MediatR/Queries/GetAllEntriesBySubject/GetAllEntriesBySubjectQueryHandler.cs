using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesBySubject
{
    public class GetAllEntriesBySubjectQueryHandler : IRequestHandler<GetAllEntriesBySubjectQueryRequest, GetAllEntriesBySubjectQueryResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetAllEntriesBySubjectQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<GetAllEntriesBySubjectQueryResponse> Handle(GetAllEntriesBySubjectQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();

            query = query.Where(e => e.Subject.Trim().ToLower().Contains(request.EntrySubject.Trim().ToLower()));

            query = query.Take(request.Count);

            var getEntryDtos = await query.ProjectTo<GetEntryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GetAllEntriesBySubjectQueryResponse()
            {
                Response = new SuccessfulDataBearerServiceResponse<List<GetEntryDto>>
                (title: ServerTitles.Successful, message: ServerMessages.EntriesRecieved, data: getEntryDtos, devNote: "")
            };
        }
    }
}
