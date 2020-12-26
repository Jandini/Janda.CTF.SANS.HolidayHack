using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class OpenHIDLock : IChallenge
    {
        private readonly ILogger<OpenHIDLock> _logger;

        public OpenHIDLock(ILogger<OpenHIDLock> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                #db# TAG ID: 2006e22f0e (6023) - Format Len: 26 bit - FC: 113 - Card: 6023
            ".LogMessage(_logger, "Open proxmark and call {command} next to {elf} in {room}", "lf hid read", "Bow Ninecandle", "TalksLobby");
        }
    }
}
