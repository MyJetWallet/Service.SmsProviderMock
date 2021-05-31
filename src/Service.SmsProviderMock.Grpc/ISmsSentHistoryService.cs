using System.ServiceModel;
using Service.SmsProviderMock.Grpc.Models.Requests;
using Service.SmsProviderMock.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Grpc
{
    [ServiceContract]
    public interface ISmsSentHistoryService
    {
        [OperationContract]
        LastSentSmsResponse GetLastSentSms(GetLastSentSmsRequest request);
    }
}
