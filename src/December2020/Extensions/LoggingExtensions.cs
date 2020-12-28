using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Janda.CTF
{
    public static class LoggingExtensions
    {       
        public static T LogNote<T>(this T o, ILogger logger, string message = "", params object[] args)
        {
            var parameters = new List<object>();

            parameters.AddRange(args);
            parameters.Add(o);

            logger.LogInformation(message + "\n{@o}", parameters.ToArray());

            return o;
        }
    }
}
