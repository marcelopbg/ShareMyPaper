using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Application.Interfaces.Services;
public interface ITokenService
{
    string BuildToken(ApplicationUser user);
    bool IsTokenValid(string token);
}
