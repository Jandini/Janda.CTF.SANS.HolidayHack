namespace Janda.CTF.SANS.HolidayHack
{       
    class Program 
    {
        [CTF(Name = "SANS Holiday Hack, December 2020")]
        static void Main(string[] args) => CTF.Run(args, (services) => services
            .AddDictionary());
    }
}