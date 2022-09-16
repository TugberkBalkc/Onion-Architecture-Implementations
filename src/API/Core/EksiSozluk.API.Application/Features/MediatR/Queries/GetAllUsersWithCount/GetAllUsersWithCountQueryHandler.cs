using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllUsersWithCount
{
    public class GetAllUsersWithCountQueryHandler : IRequestHandler<GetAllUsersWithCountQueryRequest, GetAllUsersWithCountQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersWithCountQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetAllUsersWithCountQueryResponse> Handle(GetAllUsersWithCountQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _userRepository.AsQueryable();

            query = query
                .OrderBy(u => Guid.NewGuid())
                .Take(request.Count);

            var getUserDtos = await query.ProjectTo<GetUserDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GetAllUsersWithCountQueryResponse()
            {
                Response = new SuccessfulDataBearerServiceResponse<List<GetUserDto>>
                (title: ServerTitles.Successful, message: ServerMessages.EntriesRecieved, data: getUserDtos, devNote: "")
            };
        }
    }
}
