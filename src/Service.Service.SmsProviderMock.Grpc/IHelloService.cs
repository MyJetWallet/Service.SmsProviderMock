using System.ServiceModel;
using System.Threading.Tasks;
using Service.Service.SmsProviderMock.Grpc.Models;

namespace Service.Service.SmsProviderMock.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}