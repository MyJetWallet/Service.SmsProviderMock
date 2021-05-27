using Autofac;
using Service.SmsProviderMock.Grpc;
using Service.SmsSender.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.SmsProviderMock.Client
{
    public static class AutofacHelper
    {
        public static void RegisterSmsProviderMockClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new SmsProviderMockClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetSmsSentHistoryService()).As<ISmsSentHistoryService>().SingleInstance();
            builder.RegisterInstance(factory.GetSmsDeliveryService()).As<ISmsDeliveryService>().SingleInstance();
        }
    }
}
