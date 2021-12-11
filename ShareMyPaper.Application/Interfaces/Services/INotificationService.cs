namespace ShareMyPaper.Application.Interfaces.Services;
public interface INotificationService
{
    public Task<bool> NotifyModsAboutStudentSignup(int institutionid);
    public Task<bool> SendStudentReviewNotification(string institutionModeratorMail);
}
