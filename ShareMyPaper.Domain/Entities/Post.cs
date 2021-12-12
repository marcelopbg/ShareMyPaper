namespace ShareMyPaper.Domain.Entities;
public class Post : BaseEntity
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string DocumentId { get; set; }
    public bool IsPublic { get; set; }
    public bool IsActive { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public string ApplicationUserId { get; set; }
    public KnowledgeArea KnowledgeArea { get; set; }
    public int KnowledgeAreaId { get; set; }
}
