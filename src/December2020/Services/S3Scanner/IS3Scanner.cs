using System.Collections.Generic;

namespace Janda.CTF.SANS.HolidayHack
{
    interface IS3Scanner
    {
        void Scan(IEnumerable<string> words);
    }
}
