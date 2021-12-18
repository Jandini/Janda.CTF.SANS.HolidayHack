using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Janda.CTF
{
    public class WebPageService : IWebPageService
    {
        private readonly ILogger<WebPageService> _logger;

        public WebPageService(ILogger<WebPageService> logger)
        {
            _logger = logger;
        }

        public string Download(string url)
        {
            _logger.LogTrace("Downloading page from {url}", url);
            using WebClient client = new WebClient();
            var result = client.DownloadString(url);
            _logger.LogTrace("Download complete");
            return result;
        }

        public byte[] DownloadData(string url)
        {
            _logger.LogTrace("Downloading data from {url}", url);
            using WebClient client = new WebClient();
            var result = client.DownloadData(url);
            _logger.LogTrace("Download complete");
            //result.LogAsHexDump(_logger, LogLevel.Trace, $"{result.Length} bytes downloaded");
            return result;
        }


        public string HtmlToPlainText(string html)
        {
            string buf;
            string block = "address|article|aside|blockquote|canvas|dd|div|dl|dt|" +
              "fieldset|figcaption|figure|footer|form|h\\d|header|hr|li|main|nav|" +
              "noscript|ol|output|p|pre|section|table|tfoot|ul|video";

            string patNestedBlock = $"(\\s*?</?({block})[^>]*?>)+\\s*";
            buf = Regex.Replace(html, patNestedBlock, "\n", RegexOptions.IgnoreCase);

            // Replace br tag to newline.
            buf = Regex.Replace(buf, @"<(br)[^>]*>", "\n", RegexOptions.IgnoreCase);

            // (Optional) remove styles and scripts.
            buf = Regex.Replace(buf, @"<(script|style)[^>]*?>.*?</\1>", "", RegexOptions.Singleline);

            // Remove all tags.
            buf = Regex.Replace(buf, @"<[^>]*(>|$)", "", RegexOptions.Multiline);

            // Replace HTML entities.
            buf = WebUtility.HtmlDecode(buf);
            return buf;
        }


        public string RemoveHtmlTags(string html)
        {
            return Regex.Replace(html, "<[^>]*>", string.Empty);
        }



        public string SendRequest(string url, string payload, string method = "POST", string contentType = "application/json")
        {
            WebRequest request = WebRequest.Create(url);

            request.ContentType = contentType;
            request.Method = method;

            _logger.LogTrace("{payload}", payload);
            var bytes = Encoding.UTF8.GetBytes(payload);

            _logger.LogTrace("Sending {bytes} bytes", bytes.Length);
            request.GetRequestStream().Write(bytes);

            WebResponse response = request.GetResponse();

            using Stream dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var result = reader.ReadToEnd();
            _logger.LogTrace("Response: {response}", result);

            return result;
        }


        public string PostJsonRequest(string url, object payload)
        {
            _logger.LogTrace("Serializing {@payload}", payload);
            var json = JsonSerializer.Serialize(payload);

            return SendRequest(url, json, method: "POST", contentType: "application/json");
        }

        public string PostJsonStringRequest(string url, string payload)
        {
            throw new System.NotImplementedException();
        }
    }
}
