using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge(Name = "Objective 8: Broken Tag Generator", Points = 4)]
    public class BrokenTagGenerator : IChallenge
    {
        private readonly ILogger<BrokenTagGenerator> _logger;

        public BrokenTagGenerator(ILogger<BrokenTagGenerator> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            @"
                Help Noel Boetie fix the Tag Generator in the Wrapping Room. 
                What value is in the environment variable GREETZ? 
                Talk to Holly Evergreen in the kitchen for help with this.

                https://tag-generator.kringlecastle.com/

            ".LogNote(_logger, "Objective 8");

            @"
                Hi Santa!
                If you have a chance, I'd love to get your feedback on the Tag Generator updates!
                I'm a little concerned about the file upload feature, but Noel thinks it will be fine.

                Sorry to be a pest Santa, but could you look at the Tag Generator?
                I've been looking at it, and I wonder if the source code would provide more insight?
                I told Noel we should be more careful about disclosing information in error messages.

                I tried what you suggested and enumerating all endpoints really is good idea to understand an application's functionality.
                Sometimes though, I find the Content-Type header hinders the browser more than it helps.
                Blind command injection can be frustrating though. Do you think output redirection would help?

            ".LogNote(_logger, "Holly Evergreen");

            @"
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                If you find a way to execute code blindly, I bet you can redirect to a file then download that file!

            ".LogNote(_logger, "Redirect to Download");

            @"               
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                We might be able to find the problem if we can get source code!

            ".LogNote(_logger, "Source Code Retrieval");       

            @"               
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                Once you know the path to the file, we need a way to download it!

            ".LogNote(_logger, "Download File Mechanism");

            @"                
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                Can you figure out the path to the script? It's probably on error pages!
            ".LogNote(_logger, "Error Page Message Disclosure");

            @"               
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                If you're having trouble seeing the code, watch out for the Content-Type! Your browser might be trying to help (badly)!

            ".LogNote(_logger, "Content-Type Gotcha");

            @"                
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                Is there an endpoint that will print arbitrary files?
            ".LogNote(_logger, "Endpoint Exploration");


            @"
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                I'm sure there's a vulnerability in the source somewhere... surely Jack wouldn't leave their mark?

            ".LogNote(_logger, "Source Code Analysis");

            @"
                From: Holly Evergreen
                Objective: 8) Broken Tag Generator
                Remember, the processing happens in the background so you might need to wait a bit after exploiting but before grabbing the output!
            ".LogNote(_logger, "Patience and Timing");

        }
    }
}
