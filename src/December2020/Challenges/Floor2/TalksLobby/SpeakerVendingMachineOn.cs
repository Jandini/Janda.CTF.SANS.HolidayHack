using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge(Flag = "CandyCane1")]
    public class SpeakerVendingMachineOn : IChallenge
    {
        private readonly ILogger<SpeakerVendingMachineOn> _logger;

        public SpeakerVendingMachineOn(ILogger<SpeakerVendingMachineOn> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {

            @"
                cd lab/
                rm vending-machines.json
                ./vending-machines                
                
            ".Blog(_logger, "Goto lab directory, delete vending-machines.json");

            @"                
                The elves are hungry!

                If the door's still closed or the lights are still off, you know because
                you can hear them complaining about the turned-off vending machines!
                You can probably make some friends if you can get them back on...

                Loading configuration from: /home/elf/lab/vending-machines.json

                I wonder what would happen if it couldn't find its config file? Maybe that's
                something you could figure out in the lab...

                ALERT! ALERT! Configuration file is missing! New Configuration File Creator Activated!

                Please enter the name >     
                Please enter the password > AAAAAAAAAAAAAAAAAAAAAAAA

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > AAAAAAAAAAAAAAAAAAAAAAAA
                Checking......
                That would have enabled the vending machines!

                If you have the real password, be sure to run /home/elf/vending-machines
                elf@aa086c750649 ~/lab $ cat ./vending-machines.json 
                {
                  ""name"": """",
                  ""password"": ""XiGRehmwXiGRehmwXiGRehmw""
                }
                elf @aa086c750649 ~/lab $             
            ".Blog(_logger, "We can run ./vending-machines, provide new password and then see how it looks like in the json file.");



            @"
                Please enter the password > C

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                elf@aa086c750649 ~/lab $ cat vending-machines.json 
                {
                    ""name"": """",
                    ""password"": ""L""
                }
            ".Blog(_logger, "Trying single letter... and viola first letter matches... ");





            @"                
                {
                  ""name"": ""elf - maintenance"",
                  ""password"": ""LVEdQPpBwr""                                
               }                                                
            ".Blog(_logger, "This is password we are looking for. {command}", "cat vending-machines.json");



            @"
                Please enter the name > 
                Please enter the password > Candies    

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                elf@aa086c750649 ~/lab $ cat vending-machines.json 
                {
                  ""name"": """",
                  ""password"": ""LVEd4Yb""
                }                       
            ".Blog(_logger, "Trying Candies");




            @"

                Please enter the name > 
                Please enter the password > Candyman

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                elf@aa086c750649 ~/lab $ cat vending-machines.json 
                {
                  ""name"": """",
                  ""password"": ""LVEdQRpB""
                }

            ".Blog(_logger, "Trying Candyman");




            @"
                The elves are hungry!

                If the door's still closed or the lights are still off, you know because
                you can hear them complaining about the turned-off vending machines!
                You can probably make some friends if you can get them back on...

                Loading configuration from: /home/elf/lab/vending-machines.json

                I wonder what would happen if it couldn't find its config file? Maybe that's
                something you could figure out in the lab...

                ALERT! ALERT! Configuration file is missing! New Configuration File Creator Activated!

                Please enter the name > 
                Please enter the password > Candymane1

                Welcome, ! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > 
                Checking......
                Beep boop invalid password
                {
                  ""name"": """",
                  ""password"": ""LVEdQRpBwr""
                }

            ".Blog(_logger, "rm vending-machines.json;./vending-machines;cat vending-machines.json");



            @"
                LVEdQPpBwr  -- CandyCane1
                LVEdQLpBwr  -- Candy1ane1
                LVEdQbpBwr     CandyLane1
            ".Blog(_logger, "Password was found.");



            @"
                The elves are hungry!

                If the door's still closed or the lights are still off, you know because
                you can hear them complaining about the turned-off vending machines!
                You can probably make some friends if you can get them back on...

                Loading configuration from: /home/elf/vending-machines.json

                I wonder what would happen if it couldn't find its config file? Maybe that's
                something you could figure out in the lab...

                Welcome, elf-maintenance! It looks like you want to turn the vending machines back on?
                Please enter the vending-machine-back-on code > CandyCane1
                Checking......

                Vending machines enabled!!
            ".Blog(_logger, "./vending-machines");
        }
    }
}
