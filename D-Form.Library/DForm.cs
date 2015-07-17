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

        private readonly List<FormAnswer> _formAnswers = new List<FormAnswer>();

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
        public int AnswerCount { get { return _formAnswers.Count; } }


        public DForm(string title, string author)
        {
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
            if( String.IsNullOrEmpty( author ) )
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

        public FormAnswer FindOrCreateAnswer( String uniqueName )
        {
            if( String.IsNullOrEmpty( uniqueName ) )
                throw new ArgumentException( "uniqueName", "uniqueName MUST NOT be NULL or EMPTY!" );
            FormAnswer toReturn = _formAnswers.Find( formAnswer => formAnswer.UniqueName.Equals( uniqueName, StringComparison.Ordinal ) );
            if( toReturn == null )
                toReturn = CreateAnswer( uniqueName );
            return toReturn;
        }

        public FormAnswer CreateAnswer( string uniqueName )
        {
            if( String.IsNullOrEmpty( uniqueName ) )
                throw new ArgumentException( "uniqueName", "uniqueName MUST NOT be NULL or EMPTY!" );
            _formAnswers.Add( new FormAnswer( uniqueName, this ) );
            return _formAnswers.LastOrDefault();
        }
    }
}
