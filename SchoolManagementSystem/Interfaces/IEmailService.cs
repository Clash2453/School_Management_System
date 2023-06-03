using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IEmailService
{
    public Status SendMail(EmailDto request);
}