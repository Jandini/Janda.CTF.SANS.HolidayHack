using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class LinuxPremier : IChallenge
    {
        private readonly ILogger<LinuxPremier> _logger;

        public LinuxPremier(ILogger<LinuxPremier> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
yes
ls
cat munchkin_19315479765589239 
rm munchkin_19315479765589239
pwd
ls -a
cat .bash_history
set
cd workshop/
grep -i munch *.txt
chmod +x lollipop_engine
./lollipop_engine
               
            ".LogMessage(_logger, "Complete challenge by typing following commands");

            ("chmod +x lollipop_engine" + 
                "\n" + 
                "./lollipop_engine")
                .LogMessage(_logger, "A munchkin is blocking the lollipop_engine from starting. Run the lollipop_engine binary to retrieve this munchkin.");
        }
    }
}
