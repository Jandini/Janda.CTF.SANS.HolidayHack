using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Janda.CTF.SANS.HolidayHack.Services
{
    class S3Scanner : IS3Scanner
    {
        private readonly ILogger<S3Scanner> _logger;

        public void Scan(IEnumerable<string> words)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var delay = random.Next() % 1024 + 1024;
            var seconds = 1;

            var counter = 0;
            var forbidden = 0;
            var found = 0;

            var pause = new object();

            Parallel.ForEach(words.Select(a => HttpUtility.UrlEncode(a.ToLower())), new ParallelOptions() { MaxDegreeOfParallelism = 8 }, (word) =>
            {
                Console.Title = $"Scanned: {counter} Forbidden: {forbidden}  Found: {found}  Bucket: {word}";

                if (((counter + 1) % delay) == 0)
                {
                    delay = random.Next() % 1024 + 1024;
                    seconds = random.Next() % 30 + 30;

                    Console.Title = $"Sleeping for {seconds} seconds. Next bed time in {delay} words";                    

                    lock (pause)
                        Thread.Sleep(seconds * 1000);
                }

                try
                {
                    var client = new WebClientEx() { Timeout = 100 * 1000 };

                    using Stream data = client.OpenRead($"http://s3.amazonaws.com/{word}");
                    using StreamReader reader = new StreamReader(data);
                    var response = reader.ReadToEnd();
                    _logger.LogInformation("Bucket found: {bucket}", word);

                    found++;

                    data.Close();
                    reader.Close();

                }
                catch (WebException ex)
                {
                    switch ((ex.Response as HttpWebResponse)?.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            if (word == "blast")
                                _logger.LogWarning("Something is wrong. The bucket {word} is open but it was returned as not found.", word);
                            break;

                        case HttpStatusCode.BadRequest:
                        case HttpStatusCode.MovedPermanently:
                            break;

                        case HttpStatusCode.Forbidden:
                            forbidden++;
                            _logger.LogError(ex, "Forbidden bucket: {bucket}", word);
                            break;

                        default:
                            _logger.LogCritical(ex, $"Bucket {{word}}: {ex.Message}", word);
                            break;
                    }

                    lock (pause) { };
                    Thread.Sleep(random.Next() % 500);
                }
                finally
                {
                    counter++;
                }
            });

        }
    }
}
