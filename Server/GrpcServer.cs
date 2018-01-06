
using  System;
using System.Threading.Tasks;
public class GrpcServer : System.IDisposable
{
    readonly Grpc.Core.Server _server;
    public GrpcServer(Grpc.Core.Server server)
    {
          this._server=server;

          this._server.Start();
    }
    public void Dispose()
    {
        this._server.ShutdownTask.Wait();
    }
}