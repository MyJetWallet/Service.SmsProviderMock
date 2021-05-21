using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.SmsSender.Grpc;
using Service.SmsSender.Grpc.Models.Requests;
using Service.SmsSender.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public class SmsDeliveryService : ISmsDeliveryService
    {
        private readonly ILogger<SmsDeliveryService> _logger;

        public SmsDeliveryService(ILogger<SmsDeliveryService> logger)
        {
            _logger = logger;
        }

        public Task<SendSmsResponse> SendSmsAsync(SendSmsRequest request)
        {
            var response = new SendSmsResponse {Status = true, ErrorMessage = $"{request.Phone} {request.Body}"};
            return Task.FromResult(response);
        }
    }
}
