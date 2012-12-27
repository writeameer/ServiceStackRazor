using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace MyServiceDTO
{

    [Route("/hello","GET")]
    [Route("/hello/{Name}","POST,GET")]
    public class HelloRequest : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public HelloRequest Request;
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
    }
}
