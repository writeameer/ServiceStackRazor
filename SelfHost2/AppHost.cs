using Funq;
using ServiceStack.Common.Web;
using ServiceStack.Razor;
using ServiceStack.Redis;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using System.Net;

namespace SelfHost2
{
    [Authenticate]
    class AppHost : AppHostHttpListenerBase
    {
        public static RedisAuthRepository UserRepository;

        public AppHost() : base("Test Razor", typeof(AppHost).Assembly) { }

        public override void Configure(Container container)
        {

            Plugins.Add(new RegistrationFeature());
            Plugins.Add (
                new AuthFeature 
                (
                    () => new AuthUserSession(), 
                    new IAuthProvider[]
                    {
                        new BasicAuthProvider(),
                        new CustomCredentialsAuthProvider()
                    }
                ) {HtmlRedirect = "/common/login" }
            );
            Plugins.Add(new RazorFormat());

            SetConfig(new EndpointHostConfig {
                DefaultContentType = ContentType.Json,
                CustomHttpHandlers = {
                    { HttpStatusCode.NotFound, new RazorHandler("/notfound") }
                }
            });


            container.Register<IRedisClientsManager>(new PooledRedisClientManager("localhost:6379"));
            UserRepository = new RedisAuthRepository(container.Resolve<IRedisClientsManager>());
            container.Register<IUserAuthRepository>(UserRepository);
        }
    }
}
