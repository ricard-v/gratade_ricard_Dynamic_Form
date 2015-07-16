﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Form.Library
{
    public sealed class Questions
    {
        private readonly List<QuestionBase> _questions;

        internal Questions()
        {
            _questions = new List<QuestionBase>();
        }

        public void AddNewQuestion(QuestionBase question) 
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );
            if( Contains( question ) )
                throw new ArgumentException( "question", "question CANNOT be ADDED as it ALREADY EXISTS!" );
            _questions.Add( question );
        }

        public void RemoveQuestion( QuestionBase question )
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );
            
            int index = _questions.IndexOf( question );
            if( index == -1 )
                throw new ArgumentException( "question", "question CANNOT BE REMOVED as it DOES NOT EXIST" );
            _questions.RemoveAt( index );
        }

        public bool Contains( QuestionBase question )
        {
            if( question == null )
                throw new ArgumentNullException( "question", "question MUST NOT be NULL!" );
            return _questions.Find( item => item.Title.Equals( question.Title, StringComparison.Ordinal ) ) != null;
        }
    }
}
