public class Flow
{
    public List<FlowTest> TestFlow { get; set; }
    public Result Result { get; set; }

    public Flow(IEnumerable<FlowTest> testFlow, Result result)
    {
        if (testFlow is null)
            throw new NullException(nameof(testFlow));

        if (testFlow.Count() < 2)
            throw new NullException($"{nameof(testFlow)} cannot have less than 2 values");

        if (result is null)
            throw new NullException(nameof(result));

        TestFlow = testFlow.ToList();
        Result = result;
    }

    /* public List<FlowItem> RequestFlow { get; set; } */
    /* public Result Result { get; set; } */

    /* public Flow(IEnumerable<FlowItem> requestFlow, Result result) */
    /* { */
    /*     if (requestFlow is null) */
    /*         throw new NullException(nameof(requestFlow)); */

    /*     if (requestFlow.Count() < 2) */
    /*         throw new NullException($"{nameof(requestFlow)} cannot have less than 2 values"); */

    /*     if (result is null) */
    /*         throw new NullException(nameof(result)); */

    /*     RequestFlow = requestFlow.ToList(); */
    /*     Result = result; */
    /* } */
}

/* public class FlowItem */
/* { */
/*     public Request Request { get; set; } */
/*     public object RequestResultValue { get; set; } */

/*     public FlowItem(Request request, object requestResultValue) */
/*     { */
/*         if (request is null) */
/*             throw new NullException(nameof(request)); */

/*         if (requestResultValue is null) */
/*             throw new NullException(nameof(requestResultValue)); */

/*         Request = request; */
/*         RequestResultValue = requestResultValue; */
/*     } */
/* } */
