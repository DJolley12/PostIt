using System.Net;

public class Result
{
    public HttpStatusCode ResultCode { get; set; }
    public string ResultContent { get; set; }

    public Result(HttpStatusCode resultCode, string resultContent)
    {
        if (resultContent is null)
            throw new NullException(nameof(resultContent));

        ResultCode = resultCode;
        ResultContent = resultContent;
    }
}


