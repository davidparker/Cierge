using System.Threading.Tasks;

namespace NetSo.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
