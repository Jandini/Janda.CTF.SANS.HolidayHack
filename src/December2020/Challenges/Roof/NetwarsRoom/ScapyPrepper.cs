using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class ScapyPrepper : IChallenge
    {
        private readonly ILogger<ScapyPrepper> _logger;

        public ScapyPrepper(ILogger<ScapyPrepper> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                Welcome to the ""Present Packet Prepper"" interface! The North Pole could use your help preparing pr
                esent packets for shipment.
                Start by running the task.submit() function passing in a string argument of 'start'.
                Type task.help() for help on this question.

            ".LogMessage(_logger, "task.get()");
        }
    }
}
