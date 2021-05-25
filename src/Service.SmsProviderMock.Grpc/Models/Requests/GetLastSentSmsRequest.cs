using System.Runtime.Serialization;

namespace Service.SmsProviderMock.Grpc.Models.Requests
{
    [DataContract]
    public class GetLastSentSmsRequest
    {
        [DataMember(Order = 1)]
        public int MaxCount { get; set; }
    }
}
