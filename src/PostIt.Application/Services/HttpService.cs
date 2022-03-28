using System.Net;
using System.Text;

namespace PostIt.Application
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IFileService _fileService;

        public HttpService(Uri baseAddress, IFileService fileService)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _fileService = fileService;
        }

        /* public Task<(HttpStatusCode, T)> Get<T>(string uri) */
        /* { */
        /* } */

        /* public Task<(HttpStatusCode, T)> Post<T>(string uri, object value) */
        /* { */
        /* } */
        
        /* public Task<T> Put<T>(string uri, object value) */
        /* { */
        /* } */

        /* public Task<T> Delete<T>(string uri, object value) */
        /* { */

        /* } */

        public async Task<Result> SendRequest(Request request)
        {
            var httpRequest = new HttpRequestMessage(request.Method, request.Endpoint);

            if (request.Method != HttpMethod.Get && request.Method != HttpMethod.Delete)
                httpRequest.Content = GetHttpContent(request);

            using var response = await _httpClient.SendAsync(httpRequest);
            return new Result(response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        private HttpContent GetHttpContent(Request request)
        {
            if (request.RequestContentType == RequestContentType.ApplicationJson)
            {
                return new StringContent(request.Json, Encoding.UTF8, "application/json");
            }
            else if (request.RequestContentType == RequestContentType.MultiPartFormDataContent)
            {
                var content = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(_fileService.GetFileAsBytes(request.FileData));
                content.Add(fileContent);
            }

            throw new Exception("GetHttpContent did not return valid value");
        }
    }
}
