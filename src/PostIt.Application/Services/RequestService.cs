using System.Net;

public class RequestService
{
    private readonly IHttpService _httpService;
    /* private readonly IFileService _fileService; */
    private List<Test> _tests { get; }
    private List<Flow> flows { get; set; }

    public RequestService(IHttpService httpService, IEnumerable<Test> tests)
    {
        _httpService = httpService;
        _tests = tests.ToList();
    }

    public async Task<List<TestResult>> RunAllTests()
    {
        var testResults = new List<TestResult>();
        foreach (var test in _tests)
        {
            var result = await _httpService.SendRequest(test.Request);
            var testResult = new TestResult(test.Request, test.Result, result);
            testResults.Add(testResult);
        }

        return testResults;
    }

    public async Task<List<TestResult>> RunFlows()
    {
        var flowResults = new List<TestResult>();
        foreach (var flow in flows)
        {
            var result = await RunFlow(flow);
            flowResults.Add(result);
        }
    }

    private async Task<Result> RunFlow(Flow flow)
    {
        var extractParameter = "";
        for (int i = 0; i < flow.TestFlow.Count; i++)
        {
            var test = flow.TestFlow[i];
            var result = await _httpService.SendRequest(test.Request);
            var testResult = new TestResult(test.Request, test.Result, result);

            if (!testResult.IsSuccess)
            {
                return result;
            }
            else if (i == flow.TestFlow.Count - 1)
            {
                return result;
            }

            if (result.ResultContent.Contains(test.ExtractParameter))
            {
                extractParameter = test.ExtractParameter;
            }
        }

        throw new Exception("No return for RunFlow");
    }
}
