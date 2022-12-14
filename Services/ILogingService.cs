using MyProjectSm.Models;

namespace MyProjectSm.Services
{
    public interface ILogingService
    {
        Response Login(LoginVM login);
    }
}
