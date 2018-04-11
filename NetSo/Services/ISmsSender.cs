using System.Threading.Tasks;

namespace NetSo.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
