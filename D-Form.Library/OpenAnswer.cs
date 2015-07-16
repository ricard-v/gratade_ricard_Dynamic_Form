using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class OpenAnswer : AnswerBase
    {

        private string _freeAnswer;

        public String FreeAnswer
        {
            get
            {
                return _freeAnswer;
            }
            set
            {
                
                _freeAnswer = value;
            }
        }
    }
}
