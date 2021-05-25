using System;
using System.Runtime.Serialization;
using Service.SmsSender.Domain.Models.Enums;

namespace Service.SmsProviderMock.Grpc.Models.Responses
{
    [DataContract]
    public class SentSms
    {
        [DataMember(Order = 1)] public string Id { get; set; }

        [DataMember(Order = 2)] public string Phone { get; set; }

        [DataMember(Order = 3)] public LangEnum Lang { get; set; }

        [DataMember(Order = 4)] public TemplateEnum Template { get; set; }

        [DataMember(Order = 5)] public string Text { get; set; }

        [DataMember(Order = 6)] public DateTime Date { get; set; }
    }
}
