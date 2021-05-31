using System.Runtime.Serialization;

namespace Service.SmsProviderMock.Grpc.Models.Responses
{
    [DataContract]
    public class SentSms
    {
        [DataMember(Order = 1)] public string Phone { get; set; }

        [DataMember(Order = 2)] public string Text { get; set; }

        [DataMember(Order = 3)] public long Date { get; set; }
    }
}
