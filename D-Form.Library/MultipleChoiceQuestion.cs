using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class MultipleChoiceQuestion:QuestionBase
    {
        private List<string> _choices;


         public MultipleChoiceQuestion(string title,List<string> choices )
            : base (title)
        {
            _choices = choices;
        }

         public MultipleChoiceQuestion()
            : base()
        {
            _choices = new List<string>();
        }

        public List<string> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }

        public bool AddChoice(string newChoice)
        {
            if (!_choices.Contains(newChoice))
            {
                _choices.Add(newChoice);
                return true;
            }
            else { return false; }
        }

        public bool RemoveChoice(string Choice)
        {
            if (_choices.Contains(Choice))
            {
                _choices.Remove(Choice);
                return true;
            }
            else { return false; }
        }
    }
}
