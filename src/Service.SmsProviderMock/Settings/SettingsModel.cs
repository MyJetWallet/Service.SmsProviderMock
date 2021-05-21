using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.SmsProviderMock.Settings
{
    public class SettingsModel
    {
        [YamlProperty("SmsProviderMock.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("SmsProviderMock.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("SmsProviderMock.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
