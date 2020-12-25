using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class Splunk : IChallenge
    {
        private readonly ILogger<Splunk> _logger;
        readonly IWebBrowserService _webBrowser;

        public Splunk(ILogger<Splunk> logger, IWebBrowserService webBrowser)
        {
            _logger = logger;
            _webBrowser = webBrowser;
        }

        public void Run()
        {
            "https://splunk.kringlecastle.com/en-US/account/insecurelogin?username=santa&password=2f3a4fccca6406e35bcf33e92dd93135".LogMessage(_logger, "Splunk url taken from java script page...");
            _webBrowser.Open("https://splunk.kringlecastle.com/en-US/account/insecurelogin?username=santa&password=2f3a4fccca6406e35bcf33e92dd93135");
            "| tstats count where index=* by index".LogMessage(_logger, "get indexes query");
        }
    }
}
