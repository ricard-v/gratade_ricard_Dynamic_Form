using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public abstract class QuestionBase
    {
        private string _title;
        private QuestionBase _parent;
        private readonly DForm _form;
        private readonly List<QuestionBase> _questions;


        public virtual DForm Form 
        {
            get 
            {
                return _form != null ? _form : _parent.Form;
            }
            
        }

        public int Index { get; internal set; }
        public QuestionBase Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public String Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("title", "title MUST NOT be NULL or EMPTY!");
                _title = value;
            }
        }

        public List<QuestionBase> Questions { get { return _questions; } }
        
        public QuestionBase(string title, QuestionBase parent = null)
        {
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
            _questions = new List<QuestionBase>();
            _form = null;
            _parent = parent;
            _title = title;
        }


        public bool Contains( QuestionBase question )
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );
            if( question.Parent == null )
                return false;
            else if( question.Parent != this)
                return this.Contains( question.Parent );
            else
                return true;
        }

        public void AddNewQuestion( QuestionBase question )
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );
            if (question.Parent != null)
                throw new ArgumentException( "question", "question CANNOT be ADDED as IT ALREADY HAS A PARENT!" );
            if( Contains( question ) )
                throw new ArgumentException( "question", "question CANNOT be ADDED as it ALREADY EXISTS!" );
            question.Parent = this;
            Questions.Add( question );
        }

        public void RemoveQuestion( QuestionBase question )
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );

            if( !Contains( question ) )
                throw new ArgumentException( "question", "question CANNOT BE REMOVED as it DOES NOT EXIST" );
            question.Parent = null;
            Questions.Remove( question );
        }
    }
}
 