using System.ServiceModel;
using System.Threading.Tasks;
using Service.SmsProviderMock.Grpc.Models;

namespace Service.SmsProviderMock.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}