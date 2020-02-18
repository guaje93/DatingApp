using System.Threading.Tasks;

namespace DatinApp.api.models
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> LogIn(string userName, string password);
         Task<bool> UserExists(string username);
    }
}