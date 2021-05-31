using Service.SmsProviderMock.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public interface ISmsSentStore
    {
        SentSms[] GetLastSentSmsAsync(int count);

        void StoreSentSmsAsync(SentSms sentSms);
    }
}
