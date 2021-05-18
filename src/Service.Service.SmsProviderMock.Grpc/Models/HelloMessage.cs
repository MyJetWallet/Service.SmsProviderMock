using System.Runtime.Serialization;
using Service.Service.SmsProviderMock.Domain.Models;

namespace Service.Service.SmsProviderMock.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}