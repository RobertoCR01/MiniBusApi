using Microsoft.AspNetCore.Mvc;

namespace MiniBusManagement.Api.Controllers
{
    public static class LogginController
    {
        public static void LogControllerInformation(this ILogger Ilogger, string message, Dictionary<string, object> dictionary)
        {
            using (Ilogger.BeginScope(dictionary))
            {
                Ilogger.LogInformation(message);
            }
        }
    }
}
