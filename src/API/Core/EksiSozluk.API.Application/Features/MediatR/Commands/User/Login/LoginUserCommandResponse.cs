using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Login
{
    public class LoginUserCommandResponse : CommandResponseBase<AccessToken>
    {
    }
}
