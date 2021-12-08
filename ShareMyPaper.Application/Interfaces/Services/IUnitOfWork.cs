namespace ShareMyPaper.Application.Interfaces.Services;
public interface IUnitOfWork
{
    public Task Commit();
}