using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly SortedDictionary<DateTime, SentSms> _smsSentHistory = new SortedDictionary<DateTime, SentSms>();

        public Task<LastSentSmsResponse> GetLastSentSmsAsync(GetLastSentSmsRequest request)
        {
            return Task.FromResult(new LastSentSmsResponse
            {
                SentSmsList = _smsSentHistory
                    .Take(request.MaxCount)
                    .Select(h => h.Value)
                    .ToArray()
            });
        }

        public Task<SendResponse> StoreSentSmsAsync(StoreSentSmsRequest request)
        {
            try
            {
                _smsSentHistory.Add(request.SentSms.Date, request.SentSms);
                return Task.FromResult(new SendResponse { Result = SmsSendResult.OK });
            }
            catch (Exception)
            {
                return Task.FromResult(new SendResponse { Result = SmsSendResult.FAILED });
            }
        }
    }
}
