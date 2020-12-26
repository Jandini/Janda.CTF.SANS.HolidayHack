using Janda.CTF;
using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{  
    public class SnowballFight : IChallenge
    {
        private readonly ILogger<SnowballFight> _logger;
        private readonly IWebBrowserService _webBrowser;

        public SnowballFight(ILogger<SnowballFight> logger, IWebBrowserService webBrowser)
        {
            _logger = logger;
            _webBrowser = webBrowser;
        }

        public void Run()
        {
            _webBrowser.Open("https://snowball2.kringlecastle.com/game");

        }
    }
}
