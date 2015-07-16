using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class DForm
    {
        private readonly DateTime _created;
        private readonly List<QuestionBase> _questions;
        
        public String Title { get; set; }
        public String Author { get; set; }
        public int Version { get; private set; }

        public DateTime Created { get { return _created; } }
        public DateTime LastModified { get; private set; }

        public List<QuestionBase> Questions { get { return _questions; } }

        public DForm(string title, string author)
        {
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "author", "author MUST NOT be NULL or EMPTY!" );

            _created = DateTime.UtcNow;
            LastModified = _created;
            Version = 0;
            Title = title;
            Author = author;
            _questions = new List<QuestionBase>();
        }

        public DForm()
            : this( "Undefined", "Undefined" )
        {
        }
    }
}
