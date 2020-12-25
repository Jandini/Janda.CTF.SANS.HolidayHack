using System.Collections.Generic;

namespace Janda.CTF.SANS.HolidayHack.Services
{
    interface IS3Scanner
    {
        void Scan(IEnumerable<string> words);
    }
}
