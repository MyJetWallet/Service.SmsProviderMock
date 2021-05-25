using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.SmsProviderMock.Grpc;
using Service.SmsProviderMock.Grpc.Models.Requests;
using Service.SmsProviderMock.Grpc.Models.Responses;
using Service.SmsSender.Grpc;
using Service.SmsSender.Grpc.Enums;
using Service.SmsSender.Grpc.Models.Requests;
using Service.SmsSender.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public class SmsDeliveryService : ISmsDeliveryService
    {
        private readonly ILogger<SmsDeliveryService> _logger;
        private readonly ISmsSentHistoryService _smsSentHistoryService;

        public SmsDeliveryService(ILogger<SmsDeliveryService> logger, ISmsSentHistoryService smsSentHistoryService)
        {
            _logger = logger;
            _smsSentHistoryService = smsSentHistoryService;
        }

        public async Task<SendSmsResponse> SendSmsAsync(SendSmsRequest request)
        {
            var result = await _smsSentHistoryService.StoreSentSmsAsync(new StoreSentSmsRequest
            {
                SentSms = new SentSms
                {
                    Phone = request.Phone, Text = request.Body
                }
            });

            var smsId = Guid.NewGuid().ToString();
            switch (result.Result)
            {
                case SmsSendResult.OK:
                    _logger.LogInformation("Sms with ID {smsId} has been sent successful.", smsId);
                    return new SendSmsResponse {Status = true, ReturnedId = smsId};
                case SmsSendResult.FAILED:
                    _logger.LogError("Sms sending failed.");
                    return new SendSmsResponse { Status = false, ErrorMessage = result.ErrorMessage };
                case SmsSendResult.TEMPLATE_NOT_FOUND:
                    _logger.LogError("Sms sending failed because required template not found.", smsId);
                    return new SendSmsResponse { Status = false, ErrorMessage = result.ErrorMessage };
                default:
                    _logger.LogError("System error.");
                    return new SendSmsResponse { Status = false, ErrorMessage = result.ErrorMessage };
            }
        }
    }
}
