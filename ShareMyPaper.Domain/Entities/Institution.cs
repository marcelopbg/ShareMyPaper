namespace ShareMyPaper.Domain.Entities;
public class Institution : BaseEntity
{
    public string Description { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public ICollection<ApplicationUser> ApplicationUsers { get; set; }
}