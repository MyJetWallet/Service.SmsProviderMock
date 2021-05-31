using System;
using System.Threading.Tasks;
using Service.SmsProviderMock.Grpc;
using Service.SmsProviderMock.Grpc.Models.Requests;
using Service.SmsProviderMock.Grpc.Models.Responses;
using Service.SmsSender.Grpc.Enums;
using Service.SmsSender.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public class SmsSentHistoryService : ISmsSentHistoryService
    {
        private readonly ISmsSentStore _smsSentStore;

        public SmsSentHistoryService(ISmsSentStore smsSentStore)
        {
            _smsSentStore = smsSentStore;
        }

        public LastSentSmsResponse GetLastSentSms(GetLastSentSmsRequest request)
        {
            return new LastSentSmsResponse
            {
                SentSmsList = _smsSentStore.GetLastSentSms(request.MaxCount)
            };
        }

        public Task<SendResponse> StoreSentSmsAsync(StoreSentSmsRequest request)
        {
            try
            {
                _smsSentStore.StoreSentSms(request.SentSms);
                return Task.FromResult(new SendResponse { Result = SmsSendResult.OK });
            }
            catch (Exception)
            {
                return Task.FromResult(new SendResponse { Result = SmsSendResult.FAILED });
            }
        }
    }
}
