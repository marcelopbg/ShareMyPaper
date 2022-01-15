using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Application.Validators;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ICurrentUserRepository _currentUser;
    private readonly IUnitOfWork _unitOfWork;
    public PostController(IPostRepository postRepository, ICurrentUserRepository currentUser, IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Authorize(Roles = "institution moderator, student")]
    public async Task<IActionResult> Post([FromForm] PostInputDTO post)
    {
        var validationResult = await new PostDTOValidator().ValidateAsync(post);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        var createdPost = await _postRepository.CreatePost(post, _currentUser.Email);
        return Ok(createdPost);
    }
    [HttpGet]
    public async Task<IActionResult> Get(int pageSize, int currentPage)
    {
        return Ok(await _postRepository.GetPagedPosts(currentPage, pageSize, _currentUser.Email));
    }

    [HttpGet("review")]
    [Authorize(Roles = "institution moderator")]
    public async Task<IActionResult> GetPostsForReview()
    {
        return Ok(await _postRepository
            .ListAsync(
            p => p.IsActive == false
            && p.ApplicationUser.InstitutionId == _currentUser.InstitutionId)
            );
    }
    [HttpPut("review/{postId}")]
    [Authorize(Roles = "institution moderator")]
    public async Task<IActionResult> ReviewPost([FromRoute]int postId)
    {
        var post = await _postRepository.FirstOrDefaultAsync(
            p => p.ApplicationUser.InstitutionId == _currentUser.InstitutionId
            && p.Id == postId
        );
        post.IsActive = true;
        _postRepository.Update(post);
        await _unitOfWork.Commit();
        if (post == null) return BadRequest();
        return Ok();
    }
}
