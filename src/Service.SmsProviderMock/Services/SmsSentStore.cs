using System;
using System.Collections.Generic;
using System.Linq;
using Service.SmsProviderMock.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public class SmsSentStore : ISmsSentStore
    {
        private readonly List<SentSms> _smsSentHistory = new List<SentSms>();

        public SentSms[] GetLastSentSmsAsync(int count) => _smsSentHistory.TakeLast(count).ToArray();

        public void StoreSentSmsAsync(SentSms sentSms)
        {
            try
            {
                _smsSentHistory.Add(sentSms);
                while (_smsSentHistory.Count > 100)
                {
                    _smsSentHistory.RemoveAt(0);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
