using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class OpenQuestion : QuestionBase
    {

        private bool _allowEmptyAnswer;


        public bool AllowEmptyAnswer
        {
            get
            {
                return _allowEmptyAnswer;
            }
            set { _allowEmptyAnswer = value; }
        }
        public OpenQuestion(string title, bool allowEmptyAnswer=false)
            : base (title)
        {
            _allowEmptyAnswer = allowEmptyAnswer;
        }

        public OpenQuestion()
            : base()
        {
            _allowEmptyAnswer = false;
        }

        internal override AnswerBase GetAnswerInstance(FormAnswer answerform)
        {
            return new OpenAnswer();
        }
    }
}
