using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;

namespace ShareMyPaper.Infraestructure.Repositories;
public class KnowledgeAreaRepository : GenericRepository<KnowledgeArea>, IKnowledgeAreaRepository
{
    public KnowledgeAreaRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
