using System.Text.Json;
using System.Text;

public class Request
{
    public string Endpoint { get; private set; }
    public string Json { get; private set; }
    public HttpMethod Method { get; private set; }
    public string JWT { get; private set; }
    public MultipartFormDataContent MultipartFormDataContent { get; private set; }
    public RequestContentType RequestContentType { get; private set; }
    public bool IsAuthorize { get; private set; }
    public FileData FileData { get; private set; }

    public Request(string endpoint, object value, HttpMethod method)
    {
        if (endpoint is null)
        {
            throw new NullException(nameof(endpoint));
        }
        if (value is null)
        {
            throw new NullException(nameof(value));
        }
        if (method is null)
        {
            throw new NullException(nameof(method));
        }

        Endpoint = endpoint;
        Json = JsonSerializer.Serialize(value);
        Method = method;
    }

/*     public Request(string endpoint, MultipartFormDataContent content, HttpMethod method) */
/*     { */
/*         if (endpoint is null) */
/*         { */
/*             throw new NullException(nameof(endpoint)); */
/*         } */
/*         if (content is null) */
/*         { */
/*             throw new NullException(nameof(content)); */
/*         } */
/*         if (method is null) */
/*         { */
/*             throw new NullException(nameof(method)); */
/*         } */

/*         Endpoint = endpoint; */
/*         Json = JsonSerializer.Serialize(content); */
/*         Method = method; */
/*     } */

}
/* using System.Net.Http.Headers; */
/* using System.Text.Json; */
/* using System.Text.Json.Nodes; */

/* public class Request */
/* { */
/*     public string Endpoint { get; private set; } */
/*     public HttpMethod Method { get; private set; } */

/*     public Request(string endpoint, HttpMethod method) */
/*     { */
/*         if (endpoint is null) */
/*         { */
/*             throw new NullException(nameof(endpoint)); */
/*         } */

/*         if (method is null) */
/*         { */
/*             throw new NullException(nameof(method)); */
/*         } */

/*         Endpoint = endpoint; */
/*         Method = method; */
/*     } */
/* } */

/* public class JsonRequest : Request */
/* { */
/*     public string Json { get; private set; } */

/*     public JsonRequest(string endpoint, HttpMethod method, object value) : base(endpoint, method) */
/*     { */
/*         if (value is null) */
/*         { */
/*             throw new NullException(nameof(value)); */
/*         } */

/*         Json = JsonSerializer.Serialize(value); */
/*     } */
/* } */
