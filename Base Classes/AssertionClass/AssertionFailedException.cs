using System;

namespace CSGO_Theme_Control.Base_Classes.AssertionClass
{
    /// <summary>
    /// Exception thrown when an assertion fails.
    /// </summary>
    public class AssertionFailedException : Exception
    {
            public AssertionFailedException() : base(Environment.StackTrace) { }
            public AssertionFailedException(string msg) : base(msg + "\n" + Environment.StackTrace) { }
            public AssertionFailedException(string msg, Exception inner) : base(msg + "\n" + Environment.StackTrace, inner) { }
    }
}
