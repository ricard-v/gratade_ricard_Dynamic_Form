using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D_Form.Library
{
    public sealed class FormAnswer :AnswerBase
    {
        private DForm _form;

        private Dictionary<QuestionBase, AnswerBase> _answers;

        public FormAnswer(string uniqueName, DForm form)
            : base(uniqueName)
        {
            _answers = new Dictionary<QuestionBase, AnswerBase>();
            _form = form;
        }
   
        public AnswerBase AddAnswerFor( QuestionBase question)
        {
            AnswerBase answer = question.GetAnswerInstance();
            if( _answers.ContainsKey(question))
                _answers[question] = answer;
            else
                _answers.Add(question, answer);
            return answer;
        }

        public AnswerBase FindAnswer(QuestionBase question)
        {
            return _answers.ContainsKey(question)? _answers[question]:null;
        }


    }
}
