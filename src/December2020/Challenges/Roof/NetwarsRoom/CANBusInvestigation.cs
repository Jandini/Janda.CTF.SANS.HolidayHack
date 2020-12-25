using Janda.CTF;
using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{  
    public class CANBusInvestigation : IChallenge
    {
        private readonly ILogger<CANBusInvestigation> _logger;

        public CANBusInvestigation(ILogger<CANBusInvestigation> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMWX00OkxxddcddxxkOO0XWMMMMMMMMMMMMMMMMMMMMMMMMMMMM
                MMMMMMMMMMMMMMMMMMMMMMMWXOxoc:c.;cccccc.ccccc:.:c:ldxOXMMMMMMMMMMMMMMMMMMMMMMM
                MMMMMMMMMMMMMMMMMMMMXkoc',ccccc:.:ccccc.ccccc.;cccc,'::cdOXMMMMMMMMMMMMMMMMMMM
                MMMMMMMMMMMMMMMMM0xc:cccc,':cccc::ccccccccccccccc:.;cccccc:lxXMMMMMMMMMMMMMMMM
                MMMMMMMMMMMMMMNkl,',:ccccc;;ccccccccccccccccccccc::cccccc:,',:lOWMMMMMMMMMMMMM
                MMMMMMMMMMMMNxccccc;';cccccccccccccccccccccccccccccccccc;':cccccckWMMMMMMMMMMM
                MMMMMMMMMMNdcccccc:..;cccccccccccccccccccccccccccccccccccccccccccc:kWMMMMMMMMM
                MMMMMMMMM0c,,,,:cccc;..;cccccccccccccccccccccccccccccccccccccc:,,,;:lKMMMMMMMM
                MMMMMMMWd:cccc;:cccccc;..,cccccccccccccccccccccccccccccccccccc;:cccccckMMMMMMM
                MMMMMMNlcccccccccccccccc:..,:ccccccccccccccccccccccccccccccccccccccccc:oWMMMMM
                MMMMMNc,,,,,:ccccccccccccc:..':cccccccccccccccccccccccccccccccccc:,,,,,;oWMMMM
                MMMMWoccccc::ccccccccccccccc:'.':cccccccccccccccccccccccccccccccc::ccccccxMMMM
                MMMMkccccccccccccccccccccccccc:'..:cccccccccccccccccccccccccccccccccccccc:0MMM
                MMMN::cccccccccccccccccccccccccc:'..:cccccccccccccccccccccccccccccccccccc:cWMM
                MMMk,,,,,:cccccccccccccccccccccccc:,..;ccccccccccccccccccccccccccccc:,,,,,;0MM
                MMMlccccccccccccccccccccccccccccccccc,.;cccccccccccccccccccccccccccccccccccdMM
                MMW:ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccclMM
                MMWOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO0MM
                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM

                Welcome to the CAN bus terminal challenge!

                In your home folder, there's a CAN bus capture from Santa's sleigh. Some of
                the data has been cleaned up, so don't worry - it isn't too noisy. What you
                will see is a record of the engine idling up and down. Also in the data are
                a LOCK signal, an UNLOCK signal, and one more LOCK. Can you find the UNLOCK?
                We'd like to encode another key mechanism.

                Find the decimal portion of the timestamp of the UNLOCK code in candump.log
                and submit it to ./runtoanswer!  (e.g., if the timestamp is 123456.112233,
                please submit 112233)
            ".LogMessage(_logger, "CAN bus challenge");
        }
    }
}
