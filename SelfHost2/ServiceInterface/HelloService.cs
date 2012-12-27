using MyServiceDTO;
using ServiceStack.ServiceInterface;

namespace SelfHost2.ServiceInterface
{
    [Authenticate]
    public class HelloService : Service
    {
        public object Any (HelloRequest request)
        {
            return new HelloResponse { Result = "HelloRequest, " + request.Name };
        }
    }
}
