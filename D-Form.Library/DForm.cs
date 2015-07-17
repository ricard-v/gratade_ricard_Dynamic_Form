using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class DForm
    {
        private readonly string _author;
        private readonly DateTime _created;
        private readonly QuestionRoot _questions;

        private string _title;

        public String Title
        {
            get
            {
                return _title;
            }
            set
            {
                if( String.IsNullOrEmpty( value ) )
                    throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
                _title = value;
                Version++;
                LastModified = DateTime.UtcNow;
            }
        }

        public String Author { get { return _author; } }
        public int Version { get; private set; }

        public DateTime Created { get { return _created; } }
        public DateTime LastModified { get; private set; }
        public QuestionRoot Questions { get { return _questions; } }
        

        public DForm(string title, string author)
        {
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "author", "author MUST NOT be NULL or EMPTY!" );

            _created = DateTime.UtcNow;
            LastModified = _created;
            Version = 0;
            _title = title;
            _author = author;
            _questions = new QuestionRoot( this );
        }

        public DForm()
            : this( "Undefined Title", "Undefined Author" )
        {
        }

        public FormAnswer CreateAnswer(string answer)
        {
            FormAnswer formAnswer = new FormAnswer(answer,this,null);
            return formAnswer;
        }
    }
}
