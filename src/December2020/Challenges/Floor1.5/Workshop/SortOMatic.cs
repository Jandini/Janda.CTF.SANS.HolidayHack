using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class SortOMatic : IChallenge
    {
        private readonly ILogger<SortOMatic> _logger;

        public SortOMatic(ILogger<SortOMatic> logger)
        {
            _logger = logger;
        }
        
        [Challenge]
        public void Run()
        {

            @"                
                About
                The SORT-O-MATIC is responsible for separating properly wrapped presents from disfunctional misfit presents. Properly wrapped presents are put into Santa's gift bag while the misfit toys are dropped into a box with a portal to the Island of Misfit Toys.

                The SORT-O-MATIC's configuration works using regular expressions. When all eight regular expressions match the desired values the SORT-O-MATIC will properly sort presents.

                Troubleshooting
                If the SORT-O-MATIC is NOT sorting presents at 100% accuracy, you will need to add the desired regex in the invalid (red-highlighted) inputs and then click the corresponding toggle switch. If you provide the correct regular expression and toggle the switch, the input will turn green and the progress bar will grow. You must reach 100% accuracy in order to fix the SORT-O-MATIC.

                Click on the description above each input to display a message with more details about the desired regular expression.

                Click the HELP button on the SORT-O-MATIC to view this help manual again.

            ".LogNote(_logger, "SORT-O-MATIC HELP MANUAL");
                             
            "[0-9]"
                .LogNote(_logger, "1.Matches at least one digit");

            "[A-Za-z][A-Za-z][A-Za-z]"
                .LogNote(_logger, "2.Matches 3 alpha a-z characters ignoring case");

            "[0-9a-z][0-9a-z]"
                .LogNote(_logger, "3. Matches 2 chars of lowercase a-z or numbers");

            "[A-L1-5]"
                .LogNote(_logger, "4. Matches any 2 chars not uppercase A-L or 1 - 5");

            "^[0-9][0-9][0-9]+$"
                .LogNote(_logger, "5. Matches three or more digits only");
            
            "^(([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9])$"
                .LogNote(_logger, "6. Matches multiple hour:minute: second time formats only");

            "^[a-fA-F0-9]{2}(:[a-fA-F0-9]{2}){5}$"
                .LogNote(_logger, "7. Matches MAC address format only while ignoring case. {url}", "https://ihateregex.io/expr/mac-address/");
            
            "^((0[1-9]|1[0-9])[-/.](0[1-9]|[12]\\d|3[01])[-/.][12]\\d{3})$"
                .LogNote(_logger, "8. Matches multiple day, month, and year date formats only. \n{description}", 
                @"Create a regular expression that only matches one of the three following day, month, and four digit year formats:

                10/01/1978
                01.10.1987
                14-12-1991

                However, the following values would be invalid formats:
                05/25/89
                12-32-1989
                01.1.1989
                1/1/1

                Use anchors or boundary markers to avoid matching other surrounding strings.");

        }
    }
}
