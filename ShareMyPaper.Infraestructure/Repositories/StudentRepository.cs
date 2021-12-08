using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShareMyPaper.Application.Dtos.Output;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Repositories;
public class StudentRepository : GenericRepository<ApplicationUser>, IStudentRepository
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public StudentRepository(AppDbContext dbContext,IUnitOfWork unitOfWork,IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ApproveStudentRegistration(string userId)
    {
        var user = await FirstOrDefaultAsync(
            filter: user => user.Id == userId
            && user.IsActive == false
            );
        if (user != null)
        {
            user.IsActive = true;
            Update(user);
            await _unitOfWork.Commit();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<StudentOutputDTO>> GetStudentsWithPendingApproval(int institutionId)
    {
        var result = await ListAsync(
        filter: user =>
            user.Role == "student"
            && user.IsActive == false
            && user.InstitutionId == institutionId,
        include: user => user.Include(user => user.Institution),
        orderBy: user => user.OrderBy(user => user.UserName));
        return _mapper.Map<IEnumerable<StudentOutputDTO>>(result);
    }
}
