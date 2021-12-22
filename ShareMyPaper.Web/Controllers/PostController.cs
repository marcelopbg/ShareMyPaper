using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Validators;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : Controller
{
    private readonly IPostRepository _postRepository;
    public PostController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpPost]
    [Authorize(Roles = "institution moderator, student")]
    public async Task<IActionResult> Post([FromForm] PostInputDTO post)
    {
        var validationResult = await new PostDTOValidator().ValidateAsync(post);
        if(!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        var user = new CurrentUser(HttpContext);
        var createdPost = await _postRepository.CreatePost(post, user.Email);
        return Ok(createdPost);
    }
    [HttpGet]
    public async Task<IActionResult> Get(int pageSize, int currentPage)
    {
        return Ok(await _postRepository.GetPagedPosts(currentPage, pageSize));
    }
}
