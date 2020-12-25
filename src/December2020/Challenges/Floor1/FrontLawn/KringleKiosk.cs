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

            Plant();



            _logger.LogInformation(@"Go to option {m} and enter {s}

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

                Enter choice [1 - 5] 4
                Enter your name (Please avoid special characters, they cause some weird errors)...;ls    
                 _______________________
                < Santa's Little Helper >
                 -----------------------
                  \
                   \   \_\_    _/_/
                    \      \__/
                           (oo)\_______
                           (__)\       )\/\
                               ||----w |
                               ||     ||
                welcome.sh


            ", 4, ";ls");





            _logger.LogInformation(@"Go to option 4 and enter ;cat welcome.sh

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

                Enter choice [1 - 5] 4
                Enter your name (Please avoid special characters, they cause some weird errors)...;cat welcome.sh
                 _______________________
                < Santa's Little Helper >
                 -----------------------
                  \
                   \   \_\_    _/_/
                    \      \__/
                           (oo)\_______
                           (__)\       )\/\
                               ||----w |
                               ||     ||
                #!/bin/bash

                declare -x LAST_ORDER
                LAST_ORDER=''

                # https://bash.cyberciti.biz/guide/Menu_driven_scripts
                # A menu driven shell script sample template
                ## ----------------------------------
                # Step #1: Define variables
                # ----------------------------------
                RED='\033[0;41;30m'
                STD='\033[0;0;39m'

                # ----------------------------------
                # Step #2: User defined function
                # ----------------------------------
                pause() {
                  read -r -p ""Press[Enter] key to continue..."" fackEnterKey
                }

                        one()
                        {
                            cat / opt / castlemap.txt
                          pause
                        }

                        two()
                        {
                            more / opt / coc.md
                          pause
                        }


                        three()
                        {
                            cat / opt / directory.txt
                          pause
                        }

                        four()
                        {
                            read - r - p ""Enter your name (Please avoid special characters, they cause some weird errors)..."" name
                          if [-z ""$name""]; then
                  name = ""Santa\'s Little Helper""
                          fi
                          bash - c ""/usr/games/cowsay -f /opt/reindeer.cow $name""
                          pause
                        }

                        surprise()
                        {
                            cat / opt / plant.txt
                          echo ""Sleeping for 10 seconds.."" && sleep 10
                        }

                # function to display menus
                        show_menus()
                        {
                            clear
                            echo ""~~~~~~~~~~~~~~~~~~~~~~~~~~~~""
                          echo "" Welcome to the North Pole!""
                          echo ""~~~~~~~~~~~~~~~~~~~~~~~~~~~~""
                          echo ""1. Map""
                          echo ""2. Code of Conduct and Terms of Use""
                          echo ""3. Directory""
                          echo ""4. Print Name Badge""
                          echo ""5. Exit""
                          echo
                  echo
                          echo ""Please select an item from the menu by entering a single number.""
                          echo ""Anything else might have ... unintended consequences.""
                          echo
                        }

                # read input from the keyboard and take a action
                        read_options()
                        {
                            local choice
                          read - r - p ""Enter choice [1 - 5] "" choice
                          case $choice in
                  1 *) one; ;
                            2 *) two; ;
                            3 *) three; ;
                            4 *) four $choice; ;
                            5) exit 0; ;
                            plant) surprise c; ;
                            *) echo - e ""${RED}Error...${STD}"" && sleep 2; ;
                            esac
                        }

                # ----------------------------------------------
                # Step #3: Trap CTRL+C, CTRL+Z and quit singles
                # ----------------------------------------------
                        trap '' SIGINT SIGQUIT SIGTSTP

                # -----------------------------------
                # Step #4: Show opening message once
                # ------------------------------------
                echo
                echo Welcome to our castle, we\'re so glad to have you with us!
                echo Come and browse the kiosk\; though our app\'s a bit suspicious.
                echo Poke around, try running bash, please try to come discover,
                echo Need our devs who made our app pull/patch to help recover?
                echo
                echo ""Escape the menu by launching /bin/bash""
                echo
                echo
                read -n 1 -r -s -p $'Press enter to continue...'
                clear

                # -----------------------------------
                # Step #5: Main logic - infinite loop
                # ------------------------------------

                while true; do
                  show_menus
                  read_options
                done



            ");




            _logger.LogInformation(@"Go to option {m} and enter {s}
                
                Please select an item from the menu by entering a single number.
                Anything else might have ... unintended consequences.
                Enter choice [1 - 5] 4
                Enter your name (Please avoid special characters, they cause some weird errors)...;bash
                 _______________________
                < Santa's Little Helper >
                 -----------------------
                  \
                   \   \_\_    _/_/
                    \      \__/
                           (oo)\_______
                           (__)\       )\/\
                               ||----w |
                               ||     ||
                   ___                                                      _    
                  / __|   _  _     __      __      ___     ___     ___     | |   
                  \__ \  | +| |   / _|    / _|    / -_)   (_-<    (_-<     |_|   
                  |___/   \_,_|   \__|_   \__|_   \___|   /__/_   /__/_   _(_)_  
                _|"""""""""" | _ | """"""""""|_|"""""""""" | _ | """"""""""|_|"""""""""" | _ | """"""""""|_|"""""""""" | _ | """""" | 
                ""`-0-0-'""`-0 - 0 - '""`-0-0-'""`-0-0-'""`-0 - 0 - '""`-0-0-'""`-0-0-'""`-0 - 0 - ' 
                Type 'exit' to return to the menu.
                shinny@9edb28c788e6: ~$ 

            ", 4, ";bash");


            _logger.LogInformation(
            @"Wonder around...
                Type 'exit' to return to the menu.

                shinny@9edb28c788e6:~$ ls
                welcome.sh
                shinny@9edb28c788e6:~$ cd ..
                shinny@9edb28c788e6:/home$ ls
                elf  shinny
                shinny@9edb28c788e6:/home$ whoami
                shinny
                shinny@9edb28c788e6:/home$ cd elf
                shinny@9edb28c788e6:/home/elf$ ls
                runtoanswer
                shinny@9edb28c788e6:/home/elf$ ./runtoanswer 

                Sorry, that answer is incorrect. Please try again!
            ");

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






        void Plant()
        {
            _logger.LogInformation(@"
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

                Enter choice [1 - 5] plant
                  Hi, my name is Jason the Plant!

                  ( U
                   \| )
                  __|/
                  \    /
                   \__/ ejm96
                Sleeping for 10 seconds..
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