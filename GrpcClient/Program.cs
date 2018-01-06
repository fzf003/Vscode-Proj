using System;
using Grpc.Core;
using Helloworld;
using System.Collections.Generic;
using System.Linq;
using System.Buffers;
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Threading.Tasks;
namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

   
 
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            String user = "you";

            Observable.Timer(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(10))
            .Subscribe(p =>
            {
                client.SayHelloAsync(new HelloRequest { Name = $"{user}--{p}" }).
                ResponseAsync.ToObservable().Subscribe(result =>
                             {

                                 Console.WriteLine(result.Message);
                             }, onError: ex =>
                             {

                                 Console.WriteLine(ex.Message);
                             });
            });


            Console.ReadKey();
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
