using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Janda.CTF
{
    public class WebBrowserService : IWebBrowserService
    {
        private readonly ILogger<WebBrowserService> _logger;

        public WebBrowserService(ILogger<WebBrowserService> logger)
        {
            _logger = logger;
        }

        public void Open(string url)
        {
            _logger.LogTrace("Opening {url} in default web browser", url);
            using var process = new Process();

            process.StartInfo.Verb = "open";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = url;

            process.Start();

        }
    }
}
