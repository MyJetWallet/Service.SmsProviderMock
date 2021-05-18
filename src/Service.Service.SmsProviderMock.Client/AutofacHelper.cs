using Autofac;
using Service.Service.SmsProviderMock.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.Service.SmsProviderMock.Client
{
    public static class AutofacHelper
    {
        public static void RegisterService.SmsProviderMockClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new Service.SmsProviderMockClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetHelloService()).As<IHelloService>().SingleInstance();
        }
    }
}
