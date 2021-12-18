using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Objective", Number = 3, Name = "Point-of-Sale Password Recovery", Points = 1, Flag = "santapass")]
    public class PointOfSalePasswordRecovery : IChallenge
    {
        private readonly ILogger<PointOfSalePasswordRecovery> _logger;

        public PointOfSalePasswordRecovery(ILogger<PointOfSalePasswordRecovery> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {        
            @"

                1. Install prerequites for asar archive extraction `npm install -g --engine-strict asar` (Install nodejs if you don't have it)
                2. Install santa_shop.exe ??? I would preffer not do that ... 
                3. Find app.asar in Program Files ...
                4. Extract the app.asar using `asar e app.asar .\\app`

                Password can be found in the beginning of main.js


                // Modules to control application life and create native browser window
                const { app, BrowserWindow, ipcMain } = require('electron');
                const path = require('path');

                const SANTA_PASSWORD = 'santapass';

                // TODO: Maybe get these from an API?

            ".Blog(_logger, "Solution 1: {technique}", "Use asar from npm and extract app.asar");
            

            @"

                1. Rename santa_shop.exe to santa_shop.exe.7z
                2. Open santa_shop.exe.7z with 7z interface and go to:  santa-shop.exe.7z\$PLUGINSDIR\app-64.7z\resources\
                3. View app.asar file...
                

                       ý  {""files"":{""README.md"":{""size"":79,""offset"":""0""},""index.html"":{""size"":1284,""offset"":""79""},""main.js"":{""size"":2713,""offset"":""1363""},""package.json"":{""size"":202,""offset"":""4076""},""preload.js"":{""size"":138,""offset"":""4278""},""renderer.js"":{""size"":5984,""offset"":""4416""},""style.css"":{""size"":3801,""offset"":""10400""},""img"":{""files"":{""network1.png"":{""size"":35028,""offset"":""14201""},""network2.png"":{""size"":31636,""offset"":""49229""},""network3.png"":{""size"":29293,""offset"":""80865""},""network4.png"":{""size"":25457,""offset"":""110158""}}}}}   Remember, if you need to change Santa's passwords, it's at the top of main.js!
                <!DOCTYPE html>
                <html>
                    <head>
                    <meta charset=""UTF-8"">
                    <!-- https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP -->
                    <meta http-equiv=""Content-Security-Policy"" content=""default-src 'self'; script-src 'self'"">
                    <meta http-equiv=""X-Content-Security-Policy"" content=""default-src 'self'; script-src 'self'"">
                    <link rel=""stylesheet"" href=""style.css"">

                    <title>Santa PoS</title>
                    </head>
                    <body>
                    <h1>Santa PoS</h1>

                    <div id=""header"">
                        <p id=""header-left"">SantaPOS v1.0</p>
                        <p id=""header-right"">User: elf </p>
                    </div>

                    <div id=""network-container"">
                        <img alt=""network"" id=""network"" src=""img/network1.png"" />
                    </div>

                    <div id=""cart"">
                    </div>

                    <div id=""totals"">
                        <div id=""totals-inside"">
                        <div id=""subtotal"">$0.00</div>
                        <div id=""tax"">$0.00 @ 0%</div>
                        <div id=""total"">$0.00</div>

                        <div id=""buttons"">
                            <button id=""voidTransaction"" class=""red-button"">Void</button>
                            <button id=""checkout"" class=""green-button"">Checkout</button>
                        </div>
                        </div>
                    </div>

                    <div id=""products""></div>

                    <div id=""overlay""></div>
                    <div id=""overlay-content-outer""></div>
                    <div id=""overlay-content-inner""></div>

                    <script src=""./renderer.js""></script>
                    </body>
                </html>
                // Modules to control application life and create native browser window
                const { app, BrowserWindow, ipcMain } = require('electron');
                const path = require('path');

                const SANTA_PASSWORD = 'santapass';

            ".Blog(_logger, "Solution 2: {technique}", "Use 7zip only");
        }
    }
}
