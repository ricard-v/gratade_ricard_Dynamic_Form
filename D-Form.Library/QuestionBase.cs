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

        public int Index{get;internal set;}
        public QuestionBase Parent
        {
            get
            {
                return _parent;
            }
            internal set
            {
                _parent=value;
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

        public QuestionBase(string title, QuestionBase parent = null)
        {
            if( String.IsNullOrEmpty( title ) )
                throw new ArgumentException( "title", "title MUST NOT be NULL or EMPTY!" );
            _parent = parent;
            _title = title;
        }

    }
}
 