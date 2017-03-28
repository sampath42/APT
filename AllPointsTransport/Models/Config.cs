using System;
using System.Configuration;

namespace AllPointsTransport.Models
{
    public static class Config
    {

        private static string _webApiUrl = Convert.ToString(ConfigurationManager.AppSettings["WebApiUrl"]);

        private static string _encryptionKey = Convert.ToString(ConfigurationManager.AppSettings["EncryptionKey"]);

        public static string WebApiUrl
        {
            get
            {
                return _webApiUrl;
            }          
        }

        public static string EncryptionKey
        {
            get
            {
                return _encryptionKey;
            }           
        }
    }
}