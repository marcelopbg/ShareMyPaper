using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using ShareMyPaper.Infraestructure.Objects;
using System;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Services;
public class MailService : IMailService
{
    private readonly IConfiguration _configuration;
    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<bool> SendMailAsync(Email mailData)
    {
        var apiKey = _configuration["SendGridApiKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(_configuration["MailSenderAddress"], _configuration["MailSenderName"]);
        var subject = mailData.Subject;
        var to = new EmailAddress(mailData.RecipientMail, mailData.RecipientName);
        var plainTextContent = mailData.PlainTextContent;
        var htmlContent = mailData.HtmlContent;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
        Console.WriteLine($"email notification sent to ${mailData.RecipientMail}, response status was: ${response.IsSuccessStatusCode}");
        return response.IsSuccessStatusCode;
    }
}

