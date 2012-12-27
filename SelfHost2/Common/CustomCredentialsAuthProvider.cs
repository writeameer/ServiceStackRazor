using System.Collections.Generic;
using MyServiceDTO;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace SelfHost2
{
    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            //Add here your custom auth logic (database calls etc)
            //Return true if credentials are valid, otherwise false
            var client = new JsonServiceClient
                             {
                                 BaseUri = "http://10.1.1.106:2001/",
                                 UserName = userName,
                                 Password = password
                             };

            var result = client.Post(new HelloRequest{Name="ameer"});
            if (result.Result != null) return true;
            return false;
        }

        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            //Fill the IAuthSession with data which you want to retrieve in the app eg:
            //session.FirstName = "some_firstname_from_db";
            //...

            //Important: You need to save the session!
            authService.SaveSession(session, SessionExpiry);
        }
    }
}
