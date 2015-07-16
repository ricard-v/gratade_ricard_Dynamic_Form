using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public abstract class AnswerBase
    {
        private string _uniqueName;

        public string UniqueName
        {
            get { return _uniqueName; }
            set { _uniqueName = value; }
        }
    }
}
