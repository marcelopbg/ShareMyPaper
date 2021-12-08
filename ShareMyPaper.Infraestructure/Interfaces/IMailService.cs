using ShareMyPaper.Infraestructure.Objects;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Services;
public interface IMailService
{
    public Task<bool> SendMailAsync(Email mailData);
}
