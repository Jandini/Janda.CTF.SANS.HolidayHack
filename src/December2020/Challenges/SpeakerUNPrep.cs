using Janda.CTF;
using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{  
    public class SpeakerUNPrep : IChallenge
    {
        private readonly ILogger<SpeakerUNPrep> _logger;

        public SpeakerUNPrep(ILogger<SpeakerUNPrep> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            Door();
        }


        [Challenge(Flag = "Op3nTheD00r")]
        public void Door()
        {
            @"
                    ��z9��z9���7��z9��z9��z9��z9���7���U��V��0V���U��V��MZ���Z��|Z���Z���Z��R[���[��~[���[���[��/home/
                    elf/doorYou look at the screen. It wants a password. You roll your eyes - the 
                    password is probably stored right in the binary. There's gotta be a
                    tool for this...
                    What do you enter? > opendoor   (bytes Overflowextern "" NulErrorBox<Any>thread 'expected, found Do
                    or opened!
                    That would have opened the door!
                    Be sure to finish the challenge in prod: And don't forget, the password is ""Op3nTheD00r""
                    Beep boop invalid password
                    src/liballoc/raw_vec.rscapacity overflowa formatting trait implementation returned an error/usr/sr
                    c/rustc-1.41.1/src/libcore/fmt/mod.rsstack backtrace:
                                      -       �cannot panic during the backtrace function/usr/src/rustc-1.41.1/vendor/
                    backtrace/src/lib.rsSomething went wrong: Checking...Something went wrong reading input: Something
                     went wrong in the environment: couldn't get the executable name
                    Something went wrong in the environment: RESOURCE_IDThe error message is: ask for help!
                    or su or some other process that alters the environment. If this persists, please
                    the NoneSome <= Zerokind    __ZNshim as u128i128charboolmut for< -> dyn  mainfull/ at  environment
                    al variable is missing - that can happen if you're using sudo

            ".LogMessage(_logger, "cat door");

        }
    }
}
