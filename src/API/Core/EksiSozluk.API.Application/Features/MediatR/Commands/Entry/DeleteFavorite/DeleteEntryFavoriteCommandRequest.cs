using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.RemoveFavorite
{
    public class DeleteEntryFavoriteCommandRequest : IRequest<DeleteEntryFavoriteCommandResponse>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
    }
}
