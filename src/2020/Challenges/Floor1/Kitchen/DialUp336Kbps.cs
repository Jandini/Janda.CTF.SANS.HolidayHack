using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Game", Name = "33.6Kbps")]
    public class DialUp336Kbps : IChallenge
    {
        private readonly ILogger<DialUp336Kbps> _logger;

        public DialUp336Kbps(ILogger<DialUp336Kbps> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                We can shuffle the colors of the lights by connecting via dial-up, but our only modem is broken!
                Fortunately, I speak dial-up. However, I can't quite remember the handshake sequence.
                Maybe you can help me out? The phone number is 756-8347; you can use this blue phone.

                ...

                ""Put it in the cloud,"" they said...

            ".Blog(_logger, "Fitzy Shortstack");

            // ["pickup","dtmf7","dtmf5","dtmf6","dtmf8","dtmf3","dtmf4","dtmf7", "respCrEsCl","ack","cm_cj","l1_l2_info","trn"].forEach((step)=> document.getElementsByClassName(step)[0].click());
            @"[""pickup"",""dtmf7"",""dtmf5"",""dtmf6"",""dtmf8"",""dtmf3"",""dtmf4"",""dtmf7"", ""respCrEsCl"",""ack"",""cm_cj"",""l1_l2_info"",""trn""].forEach((step)=> document.getElementsByClassName(step)[0].click());"
                .Blog(_logger, "Run from console to call");
        }
    }
}