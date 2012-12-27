using System.Threading;
using ServiceStack.Text;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;

namespace SelfHost2
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            LogManager.LogFactory = new ConsoleLogFactory();

            var appHost = new AppHost();
            appHost.Init();
            appHost.Start("http://*:2001/");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
