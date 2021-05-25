using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using JetBrains.Annotations;
using MyJetWallet.Sdk.GrpcMetrics;
using ProtoBuf.Grpc.Client;
using Service.SmsProviderMock.Grpc;
using Service.SmsSender.Grpc;

namespace Service.SmsProviderMock.Client
{
    [UsedImplicitly]
    public class SmsProviderMockClientFactory
    {
        private readonly CallInvoker _channel;

        public SmsProviderMockClientFactory(string grpcServiceUrl)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(grpcServiceUrl);
            _channel = channel.Intercept(new PrometheusMetricsInterceptor());
        }

        public ISmsSentHistoryService GetSmsSentHistoryService() => _channel.CreateGrpcService<ISmsSentHistoryService>();

        public ISmsDeliveryService GetSmsDeliveryService() => _channel.CreateGrpcService<ISmsDeliveryService>();
    }
}
