using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public class AnswerBase
    {
        private string _uniqueName;

        public string UniqueName{ get { return _uniqueName; }}

        private object _answer;

        public AnswerBase(string uniqueName,object answer)
        {
            _uniqueName = uniqueName;
            _answer = answer;
        }
        public AnswerBase()
        {
            _uniqueName = "Default";
        }
    }
}
