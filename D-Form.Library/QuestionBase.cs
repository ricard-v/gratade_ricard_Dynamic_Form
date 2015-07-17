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
        internal readonly List<QuestionBase> questions;

        internal abstract AnswerBase GetAnswerInstance(FormAnswer answerForm);
        public virtual DForm Form 
        {
            get 
            {
                return _form != null ? _form : _parent.Form;
            }
            
        }

        public QuestionBase Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if( _parent != null )
                    _parent.questions.Remove( this );
                if( value != null )
                    value.questions.Add( this );
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

        public int Index
        {
            get
            {
                if( _parent == null )
                    return -1;
                else
                    return _parent.questions.IndexOf( this );
            }
            set
            {
                if( value < 0 )
                    throw new ArgumentException( "index", "index CANNOT be NEGATIVE" );
                else if( value >= _parent.questions.Count )
                    throw new IndexOutOfRangeException( "index is out of range" );
                else if( value == Index )
                    return;
                else
                {
                    _parent.questions.Remove( this );
                    _parent.questions.Insert( value, this );
                }
            }
        }


       
        public QuestionBase(string title, QuestionBase parent = null)
        {
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
            questions = new List<QuestionBase>();
            _form = null;
            _parent = parent;
            _title = title;
        }

        public QuestionBase()
        {
            questions = new List<QuestionBase>();
            _form = null;
            _parent = null;
            _title = "default Titlte";
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
            if( Contains( question ) )
                throw new ArgumentException( "question", "question CANNOT be ADDED as it ALREADY EXISTS!" );
            question.Parent = this;
        }

        public QuestionBase AddNewQuestion(Type typeQuestion)
        {
            if( typeQuestion == null )
                throw new ArgumentNullException( "typeQuestion", "typeQuestion MUST NOT be NULL!" );
            QuestionBase instance = (QuestionBase)Activator.CreateInstance( typeQuestion );
            instance.Parent = this;
            return instance;
        }

        public void RemoveQuestion( QuestionBase question )
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );
            if( !Contains( question ) )
                throw new ArgumentException( "question", "question CANNOT BE REMOVED as it DOES NOT EXIST" );
            question.Parent = null;
        }
    }
}
 