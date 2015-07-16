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
            DForm form = new DForm("Title", "Nunit");

            Assert.Throws<ArgumentNullException>( () => form.Questions.AddNewQuestion( null ) );

            QuestionBase q1 = new OpenQuestion("First Question");
            QuestionBase q2 = new OpenQuestion( "Second Question" );
            form.Questions.AddNewQuestion( q1 );
            Assert.IsTrue( form.Questions.Contains( q1 ) );
            Assert.Throws<ArgumentException>( () => form.Questions.AddNewQuestion( q1 ) );
            Assert.DoesNotThrow( () => form.Questions.AddNewQuestion( q2 ) );
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
            Assert.IsFalse( form.Questions.Contains( q1 ) );
        }
    }
}
