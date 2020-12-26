using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class DefeatFingerprintSensor : IChallenge
    {
        private readonly ILogger<DefeatFingerprintSensor> _logger;

        public DefeatFingerprintSensor(ILogger<DefeatFingerprintSensor> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                <body class=""marble portals nut2 nut candycane ball yellowlight elevator-key greenlight redlight workshop-button"">
                    <div class=""box-parent"">
                      <canvas id=""stage"" class=""juice"" width=""563"" height=""600""></canvas>
                      <div class=""glow red"" style=""background-position: 0px -216px;""></div>
                      <div class=""glow yellow"" style=""background-position: 0px 0px;""></div>
                      <div class=""glow green"" style=""background-position: 0px -108px;""></div>
                      <div class=""led red on""></div>
                      <div class=""led yellow""></div>
                      <div class=""led green on""></div>
                      <div class=""print-indicator""></div>
                      <div class=""help-overlay""></div>
                      <button class=""reset-btn"">Reset Configuration</button>
                      <button class=""help-btn"">Help</button>
                    <div class=""item planet marble"" data-type=""planet"" data-name=""marble"" style=""left: 547px; top: 313px;""></div><div class=""item light redlight"" data-type=""light"" data-name=""redlight"" style=""left: 253px; top: 40.5px;""></div><div class=""item light yellowlight"" data-type=""light"" data-name=""yellowlight"" style=""left: 158px; top: 336.5px;""></div><div class=""item light greenlight"" data-type=""light"" data-name=""greenlight"" style=""left: 448px; top: 47.5px;""></div><div class=""item item nut"" data-type=""item"" data-name=""nut"" style=""left: 532px; top: 336px;""></div><div class=""item item nut2"" data-type=""item"" data-name=""nut2"" style=""left: 342px; top: 76px;""></div><div class=""item item ball"" data-type=""item"" data-name=""ball"" style=""left: 516.5px; top: 285.5px;""></div><div class=""item item candycane"" data-type=""item"" data-name=""candycane"" style=""left: 571px; top: 514px;""></div><div class=""item portal red"" data-type=""portal"" data-name=""red"" style=""left: 466px; top: 152px;""></div><div class=""item portal blue"" data-type=""portal"" data-name=""blue"" style=""left: 453px; top: 220px;""></div></div>
                    <div class=""cover"">
      
                      <img class=""f15btn found"" src=""images/floor1-5button.png"">
                      <div class=""key""></div>
                      <div class=""localstorage-error""><strong>Heads up:</strong> Your Santavator repair configuration cannot be accessed or saved in incognito mode.</div><div class=""print-cover""></div>
                      <button class=""btn btn1 powered"" data-floor=""1"">1</button>
                      <button class=""btn btn15 powered"" data-floor=""1.5"">1.5</button>`
                      <button class=""btn btn2 powered"" data-floor=""2"">2</button>
                      <button class=""btn btn3 active"" data-floor=""3"">3</button>
                      <button class=""btn btnr powered"" data-floor=""r"">R</button>
                    </div>
                  <script src=""app.js""></script>
                </body>
            ".LogMessage(_logger, "Change {tag} value to get to 3rd floor if the button is not powered yet.", "data-floor");
        }
    }
}
