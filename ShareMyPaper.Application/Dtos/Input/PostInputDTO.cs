using Microsoft.AspNetCore.Http;

namespace ShareMyPaper.Application.Dtos.Input;
public class PostInputDTO
{
    public string Title { get; set; }
    public string Text { get; set; }
    public bool IsPublic { get; set; }
    public IFormFile UploadedFile { get; set; }
}
