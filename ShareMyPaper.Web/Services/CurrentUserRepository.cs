using ShareMyPaper.Application.Interfaces.Repositories;

namespace ShareMyPaper.Web;
public class CurrentUserRepository : ICurrentUserRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        var user = _httpContextAccessor.HttpContext.User;
        if (user.Identity.IsAuthenticated)
        {
            if (!user.IsInRole("admin"))
            {
                var currentUserInstitution = int.Parse(user.Claims.FirstOrDefault(v => v.Type == "institution").Value);
                InstitutionId = currentUserInstitution;
            }
            Email = user.Identity.Name;
        }
        IsLoggedIn = user.Identity.IsAuthenticated;
    }

    public int InstitutionId { init; get; }
    public string Email { init; get; }
    public bool IsLoggedIn { init; get; }
}
