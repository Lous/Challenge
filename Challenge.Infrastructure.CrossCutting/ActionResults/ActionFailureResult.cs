using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.CrossCutting.ActionResults
{
    public class ActionFailureResult<TResult> : ActionResult<TResult>
    {
        public Exception Exception { get; set; }
    }

    public class ActionFailureResult : ActionResult
    {
        public Exception Exception { get; set; }
    }
}
