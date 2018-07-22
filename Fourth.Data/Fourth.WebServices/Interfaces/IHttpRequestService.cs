namespace Fourth.WebServices.Interfaces
{
    public interface IHttpRequestService
    {
        T Get<T>(string serviceUrl, string mediaType = "application/json");
    }
}
