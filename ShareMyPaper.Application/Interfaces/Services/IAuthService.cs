using Microsoft.AspNetCore.Identity;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Input.Dtos;
using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Application.Interfaces.Services;
public interface IAuthService
{
    public Task<IdentityResult> RegisterStudent(StudentInputDTO user);
    public Task<IdentityResult> RegisterInstitutionModerator(InstitutionModeratorInputDTO user);
    public Task<ApplicationUser> Login(string email, string password);
}
