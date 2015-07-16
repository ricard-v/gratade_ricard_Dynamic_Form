using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class SectionQuestion:QuestionBase
    {
        public SectionQuestion(string title,QuestionBase parent=null):base(title,parent)
        {
        }
    }
}
