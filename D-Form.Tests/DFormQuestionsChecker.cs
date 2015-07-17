using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Form.Library;
using NUnit.Framework;

namespace D_Form.Tests
{
    [TestFixture]
    public sealed class DFormQuestionsChecker
    {
        [Test]
        public void check_contains_feature()
        {
            DForm form = new DForm();
            OpenQuestion q1 = new OpenQuestion( "Q1" );
            OpenQuestion q2 = new OpenQuestion( "Q2" );
            OpenQuestion q3 = new OpenQuestion( "Q3" );
            OpenQuestion q4 = new OpenQuestion( "Q4" );

            q4.Parent = q3;
            q3.Parent = q2;
            q2.Parent = q1;

            Assert.IsTrue( q1.Contains( q4 ) );
        }

        [Test]
        public void check_questions_are_not_null_at_construction()
        {
            DForm form = new DForm();
            Assert.NotNull( form.Questions );
            form = new DForm( "Title", "Nunit" );
            Assert.NotNull( form.Questions );
        }

        [Test]
        public void check_questions_contains_feature()
        {
            DForm form = new DForm( "Title", "Nunit" );
            Assert.Throws<ArgumentNullException>( () => form.Questions.Contains( null ) );
            QuestionBase q = new OpenQuestion( "Test Question" );
            form.Questions.AddNewQuestion( q );
            Assert.IsTrue( form.Questions.Contains( q ) );
        }

        [Test]
        public void check_questions_add_feature()
        {
            DForm form = new DForm( "Title", "Nunit" );

            OpenQuestion oq = (OpenQuestion)form.Questions.AddNewQuestion( typeof( OpenQuestion ) );

            QuestionBase q1 = new OpenQuestion( "First Question" );
            QuestionBase q2 = new OpenQuestion( "Second Question" );
            form.Questions.AddNewQuestion( q1 );
            Assert.IsTrue( form.Questions.Contains( q1 ) );
            Assert.Throws<ArgumentException>( () => form.Questions.AddNewQuestion( q1 ) );
            Assert.DoesNotThrow( () => form.Questions.AddNewQuestion( q2 ) );
        }

        [Test]
        public void check_question_parent_changing()
        {
            DForm form = new DForm( "Title", "Nunit" );
            QuestionBase q1 = new OpenQuestion( "First Question" );
            QuestionBase q2 = new OpenQuestion( "Second Question" );

            q1.Parent = form.Questions;
            Assert.IsTrue( form.Questions.Contains( q1 ) );
        }

        [Test]
        public void check_questions_remove_feature()
        {
            DForm form = new DForm( "Title", "Nunit" );

            Assert.Throws<ArgumentNullException>( () => form.Questions.RemoveQuestion( null ) );

            QuestionBase q1 = new OpenQuestion( "First Question" );
            QuestionBase q2 = new OpenQuestion( "Second Question" );
            form.Questions.AddNewQuestion( q1 );
            Assert.DoesNotThrow( () => form.Questions.RemoveQuestion( q1 ) );
            Assert.IsNull( q1.Parent );
            Assert.IsFalse( form.Questions.Contains( q1 ) );
        }

        [Test]
        public void check_questions_index_changed()
        {
            DForm form = new DForm( "Title", "Nunit" );
            QuestionBase q1 = new OpenQuestion( "1st Question" );
            QuestionBase q2 = new OpenQuestion( "2nd Question" );
            QuestionBase q3 = new OpenQuestion( "3rd Question" );
            QuestionBase q4 = new OpenQuestion( "4th Question" );

            q1.AddNewQuestion( q2 );
            q1.AddNewQuestion( q3 );
            q1.AddNewQuestion( q4 );
            
            Assert.That( q2.Index, Is.EqualTo( 0 ) );
            Assert.That( q3.Index, Is.EqualTo( 1 ) );
            Assert.That( q4.Index, Is.EqualTo( 2 ) );

            Assert.Throws<ArgumentException>( () => q3.Index = -1 );

            Assert.Throws<IndexOutOfRangeException>( () => q2.Index = 3 );
            Assert.DoesNotThrow( () => q2.Index = 2 );
            Assert.IsTrue( q2.Index == 2 && q4.Index == 1 );

            Assert.DoesNotThrow( () => q2.Parent = null );
            Assert.IsTrue( q2.Index == -1 && !q1.Contains(q2) );
            
            q2.Parent = q1;
            Assert.AreEqual( 2, q2.Index );
        }
      
    }
}
