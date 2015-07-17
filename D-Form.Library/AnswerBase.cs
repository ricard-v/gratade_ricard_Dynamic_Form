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

        public AnswerBase(string uniqueName)
        {
            _uniqueName = uniqueName;
        }
        public AnswerBase()
        {
            _uniqueName = "Default";
        }
    }
}
