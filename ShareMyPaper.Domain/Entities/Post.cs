namespace ShareMyPaper.Domain.Entities;
public class Post : BaseEntity
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string DocumentId { get; set; }
    public int KnowledgeAreaId { get; set; }
    public KnowledgeArea KnowledgeArea { get; set; }

}
