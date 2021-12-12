using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : Controller
{
    private readonly IStudentRepository _studentRepository;
    private readonly IFileStorageService _fileStorageService;
    public StudentsController(
        IStudentRepository studentRepository,
        IFileStorageService fileStorageService
        )
    {
        _studentRepository = studentRepository;
        _fileStorageService = fileStorageService;
    }
    [HttpGet]
    [Route("review")]
    [Authorize(Roles = "institution moderator")]
    public async Task<IActionResult> GetStudentsWithPendingApproval()
    {
        return Ok(await _studentRepository.GetStudentsWithPendingApproval(new CurrentUser(HttpContext).InstitutionId));
    }

    [HttpPost]
    [Route("review/{studentId}")]
    [Authorize(Roles = "institution moderator")]
    public async Task<IActionResult> ReviewStudentRegistration([FromRoute]string studentId)
    {
        var result = await _studentRepository.ApproveStudentRegistration(studentId);
        return Ok(result);
    }
    [HttpGet]
    [Route("document/{documentId}")]
    [Authorize(Roles = "institution moderator")]
    public async Task<IActionResult> GetStudentDocument([FromRoute] string documentId)
    {
        var result = await _fileStorageService.GetFile(documentId);
        return Ok(result);
    }
}