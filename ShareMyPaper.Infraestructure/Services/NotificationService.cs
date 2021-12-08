﻿using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Infraestructure.Objects;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Services;
public class NotificationService : INotificationService
{
    private readonly IMailService _mailService;
    private readonly IInstitutionModeratorRepository _institutionModeratorRepository;
    public NotificationService(IMailService mailService, IInstitutionModeratorRepository institutionModeratorRepository)
    {
        _mailService = mailService;
        _institutionModeratorRepository = institutionModeratorRepository;
    }

    public async Task<bool> NotifyModsAboutStudentSignup(int institutionid)
    {
        var moderators = await _institutionModeratorRepository.GetInstitutionModeratorsByInstitution(institutionid);
        var anyNotificationHasFailed = false;
        foreach (var mod in moderators)
        {
            var notificationSucceded = await SendStudentRegistrationNotification(mod.Email);
            if (!notificationSucceded) anyNotificationHasFailed = true;
        }
        var allNotificationsSucceded = !anyNotificationHasFailed;
        return allNotificationsSucceded;
    }

    private async Task<bool> SendStudentRegistrationNotification(string institutionModeratorMail)
    {
        var maill = new Email()
        {
            RecipientName = institutionModeratorMail,
            RecipientMail = institutionModeratorMail,
            Subject = "New student signed up",
            PlainTextContent = @"Dear Institution Moderator\n 
            A new student has signed up, please log into the system and perform the pending reviews",
            HtmlContent = @"<h2> Dear Institution Moderator </h2> 
             <br>
            A new student has signed up, <b> please log into the system and perform the pending reviews </b>"

        };
        return await _mailService.SendMailAsync(maill);
    }
}
