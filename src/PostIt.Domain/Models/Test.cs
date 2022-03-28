public class Test
{
    public Request Request { get; }
    public Result Result { get; }

    public Test(Request request, Result result)
    {
        if (request is null)
            throw new NullException(nameof(request));

        if (result is null)
            throw new NullException(nameof(result));

        Request = request;
        Result = result;
    }
}

public class TestResult : Test
{
    public Result ActualResult { get; }
    public bool IsSuccess 
    { 
        get => this.Result.ResultCode == ActualResult.ResultCode 
            && this.Result.ResultContent == ActualResult.ResultContent;
    }

    public TestResult(Request request, Result result, Result actualResult) 
        : base(request, result)
    {
        ActualResult = actualResult;
    }
}

public class FlowTest : Test
{
    public string ExtractParameter { get; }

    public FlowTest(Request request, Result result, string extractParameter) 
        : base(request, result)
    {
        ExtractParameter = extractParameter;
    }
}
