using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Scenario.Core.Helpers
{
    public class Result<R>
    {
        private readonly bool _hasError;
        private readonly string _msg;
        private readonly R _res;
        private readonly List<string> _messages;

        public Result(R r, bool isError, string message)
        {
            _res = r;
            _hasError = isError;
            _msg = message;
            _messages = new List<string> { message };
        }

        public Result(R r, bool isError, Exception exp, string message)
            : this(r, isError, exp)
        {
            _messages.Insert(0, message);
        }

        public Result(R r, bool isError, Exception ex)
        {
            _res = r;
            _hasError = isError;
            _messages = new List<string>();
            _messages.AddRange(ExceptionHelper.InterpretException(ex));
            _msg = string.Join("\n", _messages);
        }

        public bool HasError
        {
            get { return _hasError; }
        }

        public string MessageResult
        {
            get { return _msg; }
        }

        public R ReturnValue
        {
            get { return _res; }
        }

        public List<string> Messages
        {
            get { return _messages; }
        }
    }
}
