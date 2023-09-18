using CybersourceNet_App.ViewModels.Request;

namespace CybersourceNet_App.Services.utils
{
    public class CybersourceConfig
    {
        private readonly Dictionary<string, string> _configurationDictionary = new();
        public Dictionary<string, string> GetConfiguration(CybersourceConfiguration cybersourceConfiguration)
        {

            _configurationDictionary.Add("authenticationType", cybersourceConfiguration.AuthenticationType);
            _configurationDictionary.Add("merchantID", cybersourceConfiguration.MerchantID);
            _configurationDictionary.Add("merchantKeyId", cybersourceConfiguration.MerchantKeyId);
            _configurationDictionary.Add("merchantsecretKey", cybersourceConfiguration.MerchantsecretKey);
            _configurationDictionary.Add("useMetaKey", cybersourceConfiguration.UseMetaKey);
            _configurationDictionary.Add("enableClientCert", cybersourceConfiguration.EnableClientCert);
            _configurationDictionary.Add("runEnvironment", cybersourceConfiguration.RunEnvironment);

            return _configurationDictionary;
        }
    }
}
