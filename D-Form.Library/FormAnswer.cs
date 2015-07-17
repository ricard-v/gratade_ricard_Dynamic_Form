using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D_Form.Library
{
    public sealed class FormAnswer
    {
        private readonly String _uniqueName;

        private DForm _form;

        private Dictionary<QuestionBase, AnswerBase> _answers;

        public String UniqueName { get { return _uniqueName; } }

        public FormAnswer(string author, DForm form)
        {
            if( String.IsNullOrEmpty( author ) )
                throw new ArgumentException( "uniqueName", "uniqueName MUST NOT be NULL or EMPTY!" );
            if( form == null )
                throw new ArgumentNullException( "form", "form MUST NOT be NULL!" );

            _form = form;
            _uniqueName = author;
            _answers = new Dictionary<QuestionBase, AnswerBase>();
        }
   
        public AnswerBase AddAnswerFor( QuestionBase question)
        {
            AnswerBase answer = question.GetAnswerInstance(this);
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
