using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : Controller
{
    private readonly IStudentRepository _studentRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly INotificationService _notificationService;
    private readonly IUnitOfWork _unitOfWork;
    public StudentsController(
        IStudentRepository studentRepository,
        IFileStorageService fileStorageService,
        INotificationService notificationService,
        IUnitOfWork unitOfWork
        )
    {
        _studentRepository = studentRepository;
        _fileStorageService = fileStorageService;
        _notificationService = notificationService;
        _unitOfWork = unitOfWork;
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
        var student = await _studentRepository.FirstAsync(
            filter: user => user.Id == studentId
            && user.IsActive == false
            );
        student.IsActive = true;
        _studentRepository.Update(student);
        await _unitOfWork.Commit();
        _ = _notificationService.SendStudentReviewNotification(student.Email);
        return Ok();
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