using ShareMyPaper.Application.Dtos.Output;
using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Application.Interfaces.Repositories;
public interface IStudentRepository : IGenericRepository<ApplicationUser>
{
    public Task<IEnumerable<StudentOutputDTO>> GetStudentsWithPendingApproval(int institutionId);

    public Task<bool> ApproveStudentRegistration(string studentId);
}
