using System;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;
using static Helloworld.Greeter;

namespace GrpcContart
{
    public class GreeterImpl : GreeterBase
    {
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            

            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }
}