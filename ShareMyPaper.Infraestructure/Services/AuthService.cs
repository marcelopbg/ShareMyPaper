using Microsoft.AspNetCore.Identity;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Input.Dtos;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Services;
public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IFileStorageService _fileStorageService;
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IKnowledgeAreaRepository _KnowledgeAreaRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IFileStorageService fileStorageService,
        IInstitutionRepository institutionRepository,
        IKnowledgeAreaRepository  knowledgeAreaRepository,
        IStudentRepository studentRepository,
        IUnitOfWork unitOfWork
        )
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _fileStorageService = fileStorageService;
        _institutionRepository = institutionRepository;
        _KnowledgeAreaRepository = knowledgeAreaRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
}
    public async Task<IdentityResult> RegisterStudent(StudentInputDTO dto)
    {

        var filePath = await _fileStorageService.UploadFileToStorage(dto.UploadedFile);

        var institution = await _institutionRepository.FirstOrDefaultAsync(inst => inst.Id == dto.InstitutionId);

        if (institution is null)
        {
            var identityError = new IdentityError[1];
            identityError[0] = new IdentityError() { Code = "InstituitionNotFound", Description = $"Institution with id: {dto.InstitutionId} Not Found" };
            return IdentityResult.Failed(identityError);
        }

        var role = await _roleManager.FindByNameAsync("student");

        var user = new ApplicationUser()
        {
            Email = dto.Email,
            UserName = dto.Email,
            DocumentId = filePath,
            DocumentExtension = System.IO.Path.GetExtension(dto.UploadedFile.FileName),
            InstitutionId = institution.Id,
            Role = "student",
            IsActive = false
        };

        var userCreationResult = await _userManager.CreateAsync(user, dto.Password);
        if (!userCreationResult.Succeeded)
        {
            return userCreationResult;
        }

        if(dto.PreferredKnowledgeAreas is not null && dto.PreferredKnowledgeAreas.Length > 0)
        {
            var knowledgeAreas = await _KnowledgeAreaRepository.ListAsync(filter: ka => dto.PreferredKnowledgeAreas.Contains(ka.Id));
            user.KnowledgeAreas = knowledgeAreas.ToList();
            _studentRepository.Update(user);
            await _unitOfWork.Commit();
        }

        var result = await _userManager.AddToRoleAsync(user, user.Role);

        return result;
    }

    public async Task<ApplicationUser> Login(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null && await _userManager.CheckPasswordAsync(user, password) && user.IsActive)
        {
            var institution = await _institutionRepository.FirstOrDefaultAsync(inst => inst.Id == user.InstitutionId);
            user.Institution = institution;
            var roles = await _userManager.GetRolesAsync(user);
            user.Role = roles.First();
            return user;
        }
        return null;
    }

    public async Task<IdentityResult> RegisterInstitutionModerator(InstitutionModeratorInputDTO dto)
    {

        var institution = await _institutionRepository.FirstOrDefaultAsync(inst => inst.Id == dto.InstitutionId);

        if (institution is null)
        {
            var identityError = new IdentityError[1];
            identityError[0] = new IdentityError() { Code = "InstituitionNotFound", Description = $"Institution with id: {dto.InstitutionId} Not Found" };
            return IdentityResult.Failed(identityError);
        }

        var role = await _roleManager.FindByNameAsync("institution moderator");

        var user = new ApplicationUser()
        {
            Email = dto.Email,
            UserName = dto.Email,
            DocumentId = "",
            DocumentExtension = "",
            InstitutionId = institution.Id,
            Role = "institution moderator",
            IsActive = true
        };

        var userCreationResult = await _userManager.CreateAsync(user, dto.Password);
        if (!userCreationResult.Succeeded)
        {
            return userCreationResult;
        }
        var result = await _userManager.AddToRoleAsync(user, user.Role);

        return result;
    }
}
