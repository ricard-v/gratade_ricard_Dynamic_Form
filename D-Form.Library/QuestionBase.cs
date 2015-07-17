﻿using System;
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

        public QuestionBase Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if( _parent != null )
                    _parent.Questions.Remove( this );
                if( value != null )
                    value.Questions.Add( this );
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
                    return _parent.Questions.IndexOf( this );
            }
            set
            {
                if( value < 0 )
                    throw new ArgumentException( "index", "index CANNOT be NEGATIVE" );
                else if( value >=_parent.Questions.Count  )
                    throw new IndexOutOfRangeException( "index is out of range" );
                else if( value == Index )
                    return;
                else
                {
                    _parent.Questions.Remove( this );
                    _parent.Questions.Insert( value, this );
                }
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
            if( Contains( question ) )
                throw new ArgumentException( "question", "question CANNOT be ADDED as it ALREADY EXISTS!" );
            question.Parent = this;
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
 