using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class SpeakerLightsOn : IChallenge
    {
        private readonly ILogger<SpeakerLightsOn> _logger;

        public SpeakerLightsOn(ILogger<SpeakerLightsOn> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                The speaker unpreparedness room sure is dark, you're thinking (assuming
                you've opened the door; otherwise, you wonder how dark it actually is)

                You wonder how to turn the lights on? If only you had some kind of hin---

                    >>> CONFIGURATION FILE LOADED, SELECT FIELDS DECRYPTED: /home/elf/lights.conf

                ---t to help figure out the password... I guess you'll just have to make do!

                The terminal just blinks: Welcome back, elf-technician

                What do you enter? > light
                Checking......
                Beep boop invalid password
            ".LogNote(_logger, "---t is {a}?, hin--- is {b}", "---t", "hin---");


            @"
                password: E$ed633d885dcb9b2f3f0118361de4d57752712c27c5316a95d9e5e5b124
                name: elf-technician
            ".LogNote(_logger, "cat /home/elf/lights.conf");



            @"
                Failed to parse key `password`: OddLength
                Password is missing from config file!
            ".LogNote(_logger, "Removed one character from the password.");


            @"Couldn't read config file: Badly formatted line (expected: ""key: value""): ".LogNote(_logger, "Remove entire password");


            @"
                elf@0e91ec090c86 ~/lab $ vi lights.conf 
                elf@0e91ec090c86 ~/lab $ ./lights       
                The speaker unpreparedness room sure is dark, you're thinking (assuming
                you've opened the door; otherwise, you wonder how dark it actually is)

                You wonder how to turn the lights on? If only you had some kind of hin---

                 >>> CONFIGURATION FILE LOADED, SELECT FIELDS DECRYPTED: /home/elf/lab/lights.conf

                ---t to help figure out the password... I guess you'll just have to make do!

                The terminal just blinks: Welcome back, Computer-TurnLightsOn

                What do you enter? > ^C
                elf@0e91ec090c86 ~/lab $ cat ./lights.conf 
                password: E$ed633d885dcb9b2f3f0118361de4d57752712c27c5316a95d9e5e5b124
                name: E$ed633d885dcb9b2f3f0118361de4d57752712c27c5316a95d9e5e5b124
                elf@0e91ec090c86 ~/lab $ 
            ".LogNote(_logger, "Rename {name} to {encrypted} in ./lab/lights.conf to get {answer}", "elf-technician", "E$ed633d885dcb9b2f3f0118361de4d57752712c27c5316a95d9e5e5b124", "Computer-TurnLightsOn");

        }
    }
}
