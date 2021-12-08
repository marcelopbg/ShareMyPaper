using Microsoft.AspNetCore.Identity;

namespace ShareMyPaper.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public string Role { get; set; }
    public string DocumentId { get; set; }
    public string DocumentExtension { get; set; }
    public int? InstitutionId { get; set; }
    public Institution Institution { get; set; }
    public ICollection<KnowledgeArea> KnowledgeAreas { get; set; }
    public bool IsActive { get; set; }
}