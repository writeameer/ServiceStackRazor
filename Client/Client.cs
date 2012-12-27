using MyServiceDTO;
using ServiceStack.ServiceClient.Web;
using System;



namespace Client
{


    class Client
    {
        static void Main()
        {
            var client = new JsonServiceClient {
                BaseUri="http://10.1.1.106:2001",
                UserName="writeameer",
                Password="password"
            };


            var result = client.Post(new HelloRequest {Name = "Ameer"}).Result;
            Console.WriteLine(result);

        }
    }
}
