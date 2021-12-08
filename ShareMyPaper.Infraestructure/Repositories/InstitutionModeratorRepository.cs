using Microsoft.EntityFrameworkCore;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Repositories;
public class InstitutionModeratorRepository : GenericRepository<ApplicationUser>, IInstitutionModeratorRepository
{
    public InstitutionModeratorRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<ApplicationUser>> GetInstitutionModeratorsByInstitution(int institutionId)
    {
        var result = await ListAsync(
            filter: user => user.InstitutionId == institutionId
            && user.Role == "institution moderator"
        );
        return result;
    }
}
