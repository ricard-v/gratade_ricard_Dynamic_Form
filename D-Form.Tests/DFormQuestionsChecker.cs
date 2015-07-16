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

            Assert.Throws<ArgumentNullException>( () => form.Questions.AddNewQuestion( null ) );

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
      
    }
}
