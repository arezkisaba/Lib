using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Core
{
    public interface IMailService
    {
        void Send(string username, string password, string from, string to, string subject, string body);

        void Send(string username, string password, string from, List<string> to, string subject, string body);

        Task SendAsync(string username, string password, string from, string to, string subject, string body);

        Task SendAsync(string username, string password, string from, List<string> to, string subject, string body);
    }
}