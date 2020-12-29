using Microsoft.Extensions.Logging;
using System.IO;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge(Name = "The Elf C0de", Flag = "")]
    public class TheElfCode : IChallenge
    {
        private readonly ILogger<TheElfCode> _logger;

        public TheElfCode(ILogger<TheElfCode> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            var files = Directory.GetFiles("Challenges", "Level-*.js", SearchOption.AllDirectories);

            foreach (var file in files)
                File.ReadAllText(file).Blog(_logger, file);
        }
    }
}
