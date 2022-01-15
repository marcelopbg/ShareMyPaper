namespace ShareMyPaper.Application.Interfaces.Repositories
{
    public interface ICurrentUserRepository
    {
        public int InstitutionId { init; get; }
        public string Email { init; get; }
        public bool IsLoggedIn { init; get; }
    }
}
