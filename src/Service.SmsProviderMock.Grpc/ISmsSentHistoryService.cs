using System.ServiceModel;
using System.Threading.Tasks;
using Service.SmsProviderMock.Grpc.Models.Requests;
using Service.SmsProviderMock.Grpc.Models.Responses;
using Service.SmsSender.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Grpc
{
    [ServiceContract]
    public interface ISmsSentHistoryService
    {
        [OperationContract]
        Task<LastSentSmsResponse> GetLastSentSmsAsync(GetLastSentSmsRequest request);

        [OperationContract]
        Task<SendResponse> StoreSentSmsAsync(StoreSentSmsRequest request);
    }
}
