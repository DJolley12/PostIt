public interface IHttpService
{
    Task<Result> SendRequest(Request request);
}
