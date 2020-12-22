using System;
using System.Net;

namespace Janda.CTF.SANS.HolidayHack.Services
{
    class WebClientEx : WebClient
    {
        public int Timeout { get; set; } = 100 * 1000;

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);
            request.Timeout = Timeout;
            return request;
        }
    }

}
