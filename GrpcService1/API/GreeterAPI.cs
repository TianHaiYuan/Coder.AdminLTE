using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcService1
{
    public class GreeterAPI : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterAPI> _logger;
        public GreeterAPI(ILogger<GreeterAPI> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }       
}
