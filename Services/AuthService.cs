using library.Entities;
using library.Data;

namespace library.Services
{
    public class AuthService
    {
        public static bool AuthenticateUser(string email, string password, out User user)
        {
            using (var context = new AppDbContext())
            {
                user = context.Users.SingleOrDefault(u => u.Email == email);
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
