using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace SelfHost2
{
    class Utils
    {
        void RegisterSampleUser()
        {
            string hash, salt;
            new SaltedHash().GetHashAndSaltString("password", out hash, out salt);

            AppHost.UserRepository.CreateUserAuth(
                    new UserAuth{
                        Id = 1,
                        DisplayName = "Ameer Deen",
                        Email = "writeameer@gmail.com",
                        FirstName = "Ameer",
                        LastName = "Deen",
                        UserName = "writeameer",
                        PasswordHash = hash,
                        Salt = salt,
                        Roles = new List<string>{RoleNames.Admin}
                    },"password"
            );
        }
    }
}
