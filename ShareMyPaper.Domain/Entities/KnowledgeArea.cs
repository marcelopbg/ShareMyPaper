namespace ShareMyPaper.Domain.Entities;
public class KnowledgeArea : BaseEntity
{
    public string Description { get; set; }
    public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    public ICollection<Post> Posts { get; set; }
}
