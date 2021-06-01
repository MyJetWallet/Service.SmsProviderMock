using Autofac;
using Service.SmsProviderMock.Services;

namespace Service.SmsProviderMock.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SmsSentStore>()
                .As<ISmsSentStore>()
                .SingleInstance();

            //for debug
            builder
                .RegisterType<SmsDeliveryService>()
                .AutoActivate();

            //for debug
            builder
                .RegisterType<SmsSentHistoryService>()
                .AutoActivate();
        }
    }
}