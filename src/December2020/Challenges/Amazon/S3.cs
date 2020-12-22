using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Janda.CTF.SANS.HolidayHack
{
    public class S3 : IChallenge
    {
        private readonly ILogger<S3> _logger;
        private readonly IDictionaryService _dictionary;

        private class WebClientEx : WebClient
        {
            public int Timeout { get; set; } = 100 * 1000;

            protected override WebRequest GetWebRequest(Uri uri)
            {
                var request = base.GetWebRequest(uri);
                request.Timeout = Timeout;
                return request;
            }
        }

        public S3(ILogger<S3> logger, IDictionaryService dictionary)
        {
            _logger = logger;
            _dictionary = dictionary;
        }

        public void Run()
        {
            var counter = 0;
            var forbidden = 0;
            var found = 0;

            Parallel.ForEach(_dictionary.GetWords().Select(a => HttpUtility.UrlEncode(a.ToLower())), new ParallelOptions() { MaxDegreeOfParallelism = 8 }, (word) =>
            {
                Console.Title = $"Scanned: {counter}  Forbidden: {forbidden}  Found: {found}  Bucket: {word}";

                try
                {
                    var client = new WebClientEx() { Timeout = 100 * 1000 };

                    using Stream data = client.OpenRead($"http://s3.amazonaws.com/{word}");
                    using StreamReader reader = new StreamReader(data);
                    var  response = reader.ReadToEnd();
                    _logger.LogInformation("Bucket found: {bucket}", word);

                    found++;
                    //_logger.LogDebug("{content}", response);

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
                            //_logger.LogError(ex, "Bucket forbidden: {bucket}", word);
                            break;

                        default:
                            _logger.LogCritical(ex, $"Bucket {{word}}: {ex.Message}", word);
                            break;
                    }
                }
                finally
                {
                    counter++;
                }
            });
        }
    }
}


