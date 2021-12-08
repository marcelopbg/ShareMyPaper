using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Application.Interfaces.Repositories;
public interface IInstitutionModeratorRepository: IGenericRepository<ApplicationUser>
{
    public Task<IEnumerable<ApplicationUser>> GetInstitutionModeratorsByInstitution(int institutionId);
}
