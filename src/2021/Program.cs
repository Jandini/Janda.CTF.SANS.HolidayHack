namespace Janda.CTF.SANS.HolidayHack
{
    class Program 
    {
        [CTF(Name = "SANS Holiday Hack, December 2021", MaximizeConsole = true)]
        static void Main(string[] args) => CTF.Run(args, (services) => services
            .AddS3Scanner()
            .AddWebBrowserService()
            .AddWebPageService()
            .AddDictionaryServices()); 
    }
}