using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Janda.CTF
{
    public static class LoggingExtensions
    {       
        public static T Blog<T>(this T o, ILogger logger, string message = "", params object[] args)
        {
            var parameters = new List<object>();

            parameters.AddRange(args);
            parameters.Add(o);

            // need to replace { with {{ and } with }}
            logger.LogInformation(message + "\n{@o}", parameters.ToArray());

            return o;
        }
    }
}
