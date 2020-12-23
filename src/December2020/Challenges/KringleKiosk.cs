using Janda.CTF;
using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class KringleKiosk : IChallenge
    {
        private readonly ILogger<KringleKiosk> _logger;

        public KringleKiosk(ILogger<KringleKiosk> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            Menu();
            Map();
            Conduct();
            Directory();
            Badge();
        }

        void Menu()
        {
            _logger.LogInformation(@"Menu

                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                 Welcome to the North Pole!
                ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                1. Map
                2. Code of Conduct and Terms of Use
                3. Directory
                4. Print Name Badge
                5. Exit


                Please select an item from the menu by entering a single number.
                Anything else might have ... unintended consequences.

                Enter choice [1 - 5] 
            ");
        }

        void Conduct()
        {
            _logger.LogInformation(@"Code of Conduct and Terms of Use 

                    # KringleCon III and Holiday Hack Challenge Code of Conduct

                    1. Use the challenges here to have fun, explore, engage, and develop your cyber security skills!

                    2. Be kind! Feel free to encourage and help other players! Let Santa's elves (support@holidayhackc
                    hallenge.com) know if something seems off. Please be mindful that there are children playing. Sant
                    a is watching!

                    3. Please don't post full answers publicly until the official contest ends on Monday, January 4, 2
                    021.

                    4. SANS Holiday Hack strives to create an atmosphere of learning, growth, and community. We value 
                    the participation and input, in this event and in the industry, of people of all genders, sexual i
                    dentities, cultures, socioeconomic backgrounds, races, ethnicities, nationalities, religions, and 
                    ages. Please support this atmosphere with respectful behavior and speech. This applies to all onli
                    ne interactions associated with KringleCon and the Holiday Hack Challenge, including game chat and
                     discussions.


                    # KringleCon III and Holiday Hack Challenge Terms of Use

                    1. This service includes a ""group chat"" component. We cannot make any guarantees about the accurac
                    y, quality, or age - appropriateness of chat messages.

                    2.All activity and interactions within Holiday Hack Challenge are monitored and recorded.We use
                    this information to maintain an environment that is both safe and conducive to learning.

                    3.Players should avoid engaging in techniques on any Holiday Hack Challenge server that may negat
                    ively affect the server's operational status and/or availability.

                    4.Players must not attack Holiday Hack Challenge servers(*.holidayhackchallenge.com, *.kringleco
                    n.com, etc.) unless otherwise directed.If you have any questions about target scope, please email
                    : support@holidayhackchallenge.com.

                    5.E - mail addresses collected will be used in accordance with the SANS Privacy Policy(https://www
                    .sans.org / privacy /).
                ");
        }


       



        void Map()
        {
            _logger.LogInformation(@"Map

                 __       _    --------------                                                
                |__)_  _ (_   | NetWars Room |                                               
                | \(_)(_)|    |              |                                               
                              |            * |                                               
                               --------------                                                
                                                                             
                __  __                              __  __                                   
                 _)|_                                _)|_          -------                   
                /__|        Tracks                  __)|          |Balcony|                  
                            1 2 3 4 5 6 7                          -------                   
                 -------    -------------                             |                      
                |Speaker|--| Talks Lobby |                        --------                   
                |Unprep |  |             |                       |Santa's |                  
                 -------    ------       |                       |Office  |                  
                                  |      |                        --    --                   
                                  |     *|                          |  |                     
                                   ------                           |   ---                  
                                                                    |    * |                 
                    __                                               ------                  
                 /||_                                                                        
                  ||                                          __ __           --------       
                  --------------------------              /| |_ |_           |Wrapping|      
                 |        Courtyard         |              |.__)|            |  Room  |      
                  --------------------------                                  --------       
                    |                    |                                       |           
                 ------    --------    ------                          ---    --------       
                |Dining|--|Kitchen |--|Great |                            |--|Workshop|      
                |      |   --------   |      |                            |  |        |      
                | Room |--|      * |--| Room |                            |  |        |      
                |      |  |Entryway|  |      |                            |  |        |      
                 ------    --------    ------                             |  |        |      
                               |                                             | *      |      
                           ----------                                         --------       
                          |Front Lawn|       NOTE: * denotes Santavator                      
                           ----------                                                        
            ");
        }

        void Directory()
        {
            _logger.LogInformation(@"Directory

                        Name: Floor: Room:
                        Ribb Bonbowford       1        Dining Room
                        Noel Boetie           1        Wrapping Room
                        Ginger Breddie        1        Castle Entry
                        Minty Candycane       1.5      Workshop
                        Angel Candysalt       1        Great Room
                        Tangle Coalbox        1        Speaker UNPreparedness
                        Bushy Evergreen       2        Talks Lobby
                        Holly Evergreen       1        Kitchen
                        Bubble Lightington    1        Courtyard
                        Jewel Loggins Front Lawn
                        Sugarplum Mary        1        Courtyard
                        Pepper Minstix Front Lawn
                        Bow Ninecandle        2        Talks Lobby
                        Morcel Nougat         2        Speaker UNPreparedness
                        Wunorse Openslae      R NetWars Room
                        Sparkle Redberry      1        Castle Entry
                        Jingle Ringford                NJTP
                        Piney Sappington      1        Castle Entry
                        Chimney Scissorsticks 2        Talks Lobby
                        Fitzy Shortstack      1        Kitchen
                        Alabaster Snowball R        NetWars Room
                        Eve Snowshoes         3        Santa's Balcony
                        Shinny Upatree                 Front Lawn
                        Tinsel Upatree        3        Santa's Office
                ");
        }

        void Badge()
        {
            _logger.LogInformation(@"Print Name Badge
                Enter your name (Please avoid special characters, they cause some weird errors)...Jandini
                 _________
                < Jandini >
                 ---------
                  \
                   \   \_\_    _/_/
                    \      \__/
                           (oo)\_______
                           (__)\       )\/\
                               ||----w |
                               ||     ||
            ");
        }
    }
}
