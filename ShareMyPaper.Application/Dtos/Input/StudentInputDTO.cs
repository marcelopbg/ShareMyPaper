using Microsoft.AspNetCore.Http;

namespace ShareMyPaper.Application.Input.Dtos;
public class StudentInputDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public int InstitutionId { get; set; }
    public IFormFile UploadedFile { get; set; }
    public int[] PreferredKnowledgeAreas { get; set; }
}
