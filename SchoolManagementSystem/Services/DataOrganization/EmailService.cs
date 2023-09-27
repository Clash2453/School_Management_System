using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services.DataOrganization;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    /// <summary>
    /// Sends an e-mail to the user's e-mail address
    /// </summary>
    /// <param name="request">The data that will be displayed in the e-mail</param>
    /// <returns></returns>
    public Status SendMail(EmailDto request)
    { 
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailHost").Value));
        email.To.Add(MailboxAddress.Parse(request.Receiver));
        email.Subject = request.Subject;
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = request.Body;
        email.Body = bodyBuilder.ToMessageBody();

        using var smtp = new SmtpClient();
        smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_configuration.GetSection("EmailAddress").Value, _configuration.GetSection("EmailPassword").Value);
        smtp.Send(email);
        smtp.Disconnect(true);
        return Status.Success; 
    }
}