using Service.SmsProviderMock.Grpc.Models.Responses;

namespace Service.SmsProviderMock.Services
{
    public interface ISmsSentStore
    {
        SentSms[] GetLastSentSms(int count);

        void StoreSentSms(SentSms sentSms);
    }
}
