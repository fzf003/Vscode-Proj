using System;
using Grpc.Core;
using GrpcContart;
using Helloworld;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {

        const int Port = 50051;

        static void Main(string[] args)
        {

Task.Run(()=>WebStart());
            
Task.Run(()=>GrpcServerStart());
 
Console.ReadKey();

        }

        static void WebStart()
        {
          /*  WebHost.CreateDefaultBuilder()
               .UseStartup<Startup>()
               .Build();
*/


               var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
              
                .Build();

            host.Run();
        }

        static void GrpcServerStart()
        {
            using (var server = new GrpcServer(new Grpc.Core.Server
            {
                Services = { Greeter.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            }))
            {
                Console.WriteLine("Greeter server listening on port " + Port);
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
            }

        }
    }
}
