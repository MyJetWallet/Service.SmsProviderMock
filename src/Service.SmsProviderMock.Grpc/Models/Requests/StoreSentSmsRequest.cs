using System.Runtime.Serialization;
using Service.SmsProviderMock.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Grpc.Models.Requests
{
    [DataContract]
    public class StoreSentSmsRequest
    {
        [DataMember(Order = 1)]
        public SentSms SentSms { get; set; }
    }
}
