using log4net;

namespace Auth.Providers
{
    public class LoggingProvider
    {
        private static readonly ILog log = 
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Log(string message)
        {
            log.Error(message);
        }
    }
}