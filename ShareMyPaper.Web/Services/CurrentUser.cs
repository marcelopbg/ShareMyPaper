namespace ShareMyPaper.Web;
public class CurrentUser
{
    public int InstitutionId { init; get; }
    public string Email { get; set; }
    public CurrentUser(HttpContext context)
    {
        var currentUserInstitution = int.Parse(context.User.Claims.FirstOrDefault(v => v.Type == "institution").Value);
        InstitutionId = currentUserInstitution;
        Email = context.User.Identity.Name;
    }
}
