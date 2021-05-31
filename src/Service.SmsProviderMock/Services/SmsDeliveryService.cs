using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.SmsProviderMock.Extensions;
using Service.SmsProviderMock.Grpc.Models.Responses;
using Service.SmsSender.Grpc;
using Service.SmsSender.Grpc.Models.Requests;
using Service.SmsSender.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public class SmsDeliveryService : ISmsDeliveryService
    {
        private readonly ILogger<SmsDeliveryService> _logger;
        private readonly ISmsSentStore _smsSentStore;

        public SmsDeliveryService(ILogger<SmsDeliveryService> logger, ISmsSentStore smsSentStore)
        {
            _logger = logger;
            _smsSentStore = smsSentStore;
        }

        public Task<SendSmsResponse> SendSmsAsync(SendSmsRequest request)
        {
            _smsSentStore.StoreSentSms(new SentSms
            {
                Phone = request.Phone,
                Text = request.Body,
                Date = DateTime.Now.ToTimestamp()
            });

            var smsId = Guid.NewGuid().ToString();

            _logger.LogInformation("Sms with fake ID {smsId} send emulation is successful.", smsId);

            return Task.FromResult(new SendSmsResponse { Status = true, ReturnedId = smsId });
        }
    }
}
