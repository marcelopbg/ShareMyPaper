using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;

namespace ShareMyPaper.Infraestructure.Repositories;
public class InstitutionRepository : GenericRepository<Institution>, IInstitutionRepository
{
    public InstitutionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
