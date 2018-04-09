using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Scenario.Core.Helpers
{
    public class MultiResult<M>
    {
        private readonly bool _hasError;
        private readonly string _msg;
        private readonly List<M> _res;
        private readonly List<string> _messages;

        public MultiResult(List<M> r, bool isError, string message)
        {
            _res = r;
            _hasError = isError;
            _msg = message;
            _messages = new List<string>();
        }

        public MultiResult(List<M> r, bool isError, Exception ex, string message) :
            this(r, isError, ex)
        {
            _messages.Insert(0, message);
        }

        public MultiResult(List<M> r, bool isError, Exception ex)
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

        public List<M> ReturnValue
        {
            get { return _res; }
        }

        public List<string> Messages
        {
            get { return _messages; }
        }
    }
}
