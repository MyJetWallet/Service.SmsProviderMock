using System.Runtime.Serialization;

namespace Service.SmsProviderMock.Grpc.Models.Responses
{
    [DataContract]
    public class LastSentSmsResponse
    {
        [DataMember(Order = 1)]
        public SentSms[] SentSmsList { get; set; }
    }
}
