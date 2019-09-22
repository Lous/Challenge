using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.CrossCutting.ActionResults
{
    public class ActionSuccessResult : ActionResult
    { }

    public class ActionSuccessResult<TResult> : ActionResult<TResult>
    {
        public TResult Result { get; set; }
    }
}
