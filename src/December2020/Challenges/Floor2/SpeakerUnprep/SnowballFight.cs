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

        }


        public void OpenWebsites()
        {
            _webBrowser.Open("https://snowball2.kringlecastle.com/game");
            _webBrowser.Open("https://github.com/tliston/mt19937/blob/main/mt19937.py");
            _webBrowser.Open("https://www.youtube.com/watch?v=Jo5Nlbqd-Vg");
            _webBrowser.Open("https://github.com/kmyk/mersenne-twister-predictor/blob/master/readme.md");
        }
    }
}
