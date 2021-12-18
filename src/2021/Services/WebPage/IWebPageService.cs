namespace Janda.CTF
{
    public interface IWebPageService 
    {
      
        string Download(string url);
        byte[] DownloadData(string url);
        string PostJsonRequest(string url, object payload);
        string SendRequest(string url, string payload, string method = "POST", string contentType = "application/json");

        string RemoveHtmlTags(string html);
        string HtmlToPlainText(string html);


    }
}
