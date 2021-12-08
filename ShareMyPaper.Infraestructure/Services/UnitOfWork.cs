using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Infraestructure.Persistence;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Services;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task Commit()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
