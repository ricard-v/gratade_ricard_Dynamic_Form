using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class QuestionRoot : QuestionBase
    {
        private readonly DForm _form;

        public override DForm Form
        {
            get
            {
                return _form != null ? _form : null;
            }

        }

        internal QuestionRoot( DForm form )
            : base( "Question Root" )
        {
            _form = form;
        }

        internal QuestionRoot()
            : base()
        {
            _form = null;
        }
    }
}
