using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Objective", Number = 4, Name = "Operate the Santavator", Points = 2)]
    public class OperateTheSantavator : IChallenge
    {
        private readonly ILogger<OperateTheSantavator> _logger;

        public OperateTheSantavator(ILogger<OperateTheSantavator> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"

                <div class=""cover"">
                    <div class=""localstorage-error""><strong>Heads up:</strong> Your Santavator repair configuration cannot be accessed or saved in incognito mode.</div>
                    <img class=""f15btn found"" src=""images/floor1-5button.png"">
                    <div class=""key""></div>
                    <div class=""print-cover""></div>
                    <button class=""btn btn1 active powered"" data-floor=""1"">1</button>
                    <button class=""btn btn15"" data-floor=""1.5"">1.5</button>`
                    <button class=""btn btn2 powered"" data-floor=""2"">2</button>
                    <button class=""btn btn3"" data-floor=""3"">3</button>
                    <button class=""btn btnr"" data-floor=""r"">R</button>
                </div>

            ".Blog(_logger, "Access panel without key... {answer}", "Hide the cover html element");

        }
    }
}
