using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{  
    [Challenge(Name = "Hidden Place")]
    public class HiddenPlace : IChallenge
    {
        private readonly ILogger<HiddenPlace> _logger;

        public HiddenPlace(ILogger<HiddenPlace> logger)
        {
            _logger = logger;
        }
        
        
        public void Run()
        {
            @"

                Ot

                tTU
                W33tT
                9999W33tT


                OP
                G\wp
                W33tT

                tTU

                W33tT

                nlt

                M00du
                vvv
                gdK
                duT

                M00du

                vvvvM00du

                gH

                nlt
                M00du
                vvv
                gdK



            ".Blog(_logger, "Booth");
        }
    }
}
