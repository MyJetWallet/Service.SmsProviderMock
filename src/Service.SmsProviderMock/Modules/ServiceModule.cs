using Autofac;
using Service.SmsProviderMock.Grpc;
using Service.SmsProviderMock.Services;
using Service.SmsSender.Grpc;

namespace Service.SmsProviderMock.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SmsSentStore>()
                .As<ISmsSentStore>()
                .AutoActivate()
                .SingleInstance();

            builder
                .RegisterType<SmsDeliveryService>()
                .As<ISmsDeliveryService>()
                .AutoActivate()
                .SingleInstance();

            builder
                .RegisterType<SmsSentHistoryService>()
                .As<ISmsSentHistoryService>()
                .AutoActivate()
                .SingleInstance();
        }
    }
}