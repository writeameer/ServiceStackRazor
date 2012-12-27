using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceHost;
using MyServiceDTO;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;

namespace SelfHost2.ServiceInterface
{
    [Route("/RegisterRequest")]
    public class RegisterService : Service
    {
        //public object Any(RegisterRequest  ) 
        public object Get(RegisterRequest request)
        {
            return new RegisterResponse { Result = "true", RegisterRequest = null};
        }

        //public object Any(RegisterRequest  ) 
        public object Post (RegisterRequest request)
        {

            string hash, salt;
            new SaltedHash().GetHashAndSaltString(request.Password, out hash, out salt);

            ResponseStatus responseStatus = null;
            Exception createUserException = null;

            try
            {
                AppHost.UserRepository.CreateUserAuth(
                    new UserAuth
                        {
                            Id = 1,
                            DisplayName = request.Email,
                            Email = request.Email,
                            UserName = request.Email,
                            PasswordHash = hash,
                            Salt = salt,
                            Roles = new List<string> {RoleNames.Admin}
                        }, request.Password
                    );
            }
            catch (Exception e)
            {
                createUserException = e;
            }

                return new RegisterResponse { Result = "true", RegisterRequest = request};
        }
    }
}
