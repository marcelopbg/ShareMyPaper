namespace ShareMyPaper.Web;
public class CurrentUser
{
    public int InstitutionId { init; get; }
    public CurrentUser(HttpContext context)
    {
        var currentUserInstitution = int.Parse(context.User.Claims.FirstOrDefault(v => v.Type == "institution").Value);
        InstitutionId = currentUserInstitution;
    }
}
