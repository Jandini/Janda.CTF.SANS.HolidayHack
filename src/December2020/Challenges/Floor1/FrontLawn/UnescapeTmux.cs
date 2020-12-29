using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Terminal", Name = "Unescape Tmux", Flag = "N/A")]
    public class UnescapeTmux : IChallenge
    {
        private readonly ILogger<UnescapeTmux> _logger;

        public UnescapeTmux(ILogger<UnescapeTmux> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                ..............................'.''''''.'''''''''''''
                .........................................'''''''''''
                ................................,:lccc:;,'...'''''''
                .............................';loodxkkxxdlc;'..'''''
                ............................,:ccllcldx0dxxdoc..'''''
                ...........................;ccclooodkOkok0OOx:..''''
                .........................':cccllodxxkkkOkxdxx;....''
                ........................,cccllooddxkOOOkOxoo'.....''
                ......................';:cclllccllodO0Okkkx;...'''..
                .....................:llollclclccccclokc::'.........
                ...................;ddollllllllcccccccl;............
                ..................:xdooddoooolclllllolld;...........
                .................'xxoodxxxdoooooooxkdooox'..........
                .................,xxkxdxkkxxdddddddxkkxdxl....'.....
                .................'xOkooddxkkxxdddxxkkxxxxx'.......'.
                ..................oOkddxkkkkdxxdddxxxxxxdd:......'.'
                .................';k0xxkxxOxdddddoodxdxkkx:....'''''
                ................'',o0xdddxkxdxdodddddkkkxxc....'''''
                ................',,:OK0kkOOxddddxxxddxxkxd:'''''''''
                .............',;:cccdKXKOkkOOxkxdxxxxxxkOx;'''''''''
                ...........:oxdddxkkxOXXOxxkxxkkkkkkkxxdxx,,''''''''
                .......''':c:,..'coodOO00OOOO00kxOkK0KkO0d,,''''''''
                ...;cllc::clddooddOkxoccccccloddxxO0KK0KKOc:;,''''''
                'ldolcc:::lldxkOxkO000OOOOkkxxdddxoooooooooodxxxddol
                xxlcc:::::xolldddxOOdddxxxkkOOO0000000xkOkkxddoooooo
                lo:::cccc::ldoodooxd,;lxxkkO0OOOOOOOOOOOOOO000000000
                locclccccccccldkxdkk:,;cdxkOKXXXKKKKKXXKk::::cllodxk
                xxollllcccllcodkOkO0:,,,:dkOOKKXXXKKKXXKl,,'''''''''
                xxkolllllllllodkO0KO;,,,;;lxO00KKXKKKKK0c;,,,,,,,,,,
                ,dxxxdoooollodxk0KOolc:::::cdO00KK00K000c;,,,,,,,,,;
                ..:xkOOkdoxxkOO0OxoooooolooodxOO00Ok0kk0oc:;;;;;;;;;
                ....:dkOddOO0OkdoolllllloooddxOOOOOkkkkOdllccccccccc

                You found her! Thank you!!!
            ".Blog(_logger, "Run {command} ", "tmux attach");
        }
    }
}
