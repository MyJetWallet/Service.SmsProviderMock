using System.Runtime.Serialization;
using Service.SmsProviderMock.Domain.Models;

namespace Service.SmsProviderMock.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}