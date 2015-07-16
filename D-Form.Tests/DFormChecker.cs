using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using D_Form.Library;
using NUnit.Framework;


namespace D_Form.Tests
{
    [TestFixture]
    public sealed class DFormChecker
    {
        private const String EmptyString = "";

        [Test]
        public void check_default_constructor()
        {
            DForm form = new DForm();
            Assert.That( form.Title, Is.EqualTo( "Undefined Title" ) );
            Assert.That( form.Author, Is.EqualTo( "Undefined Author" ) );
            Assert.That( form.Version, Is.EqualTo( 0 ) );
            Assert.That( form.Created, Is.EqualTo( form.LastModified ) );
        }

        [Test]
        public void check_main_construtor_with_parameters()
        {
            // Checking if parameters sent to constructor are not changed in the process
            DForm form = new DForm( "Form Test Creation", "Nunit" );
            Assert.That( form.Title, Is.EqualTo( "Form Test Creation" ) );
            Assert.That( form.Author, Is.EqualTo( "Nunit" ) );
            Assert.That( form.Version, Is.EqualTo( 0 ) );
            Assert.That( form.Created, Is.EqualTo( form.LastModified ) );
        }


        [TestCase( null, null )]
        [TestCase( EmptyString, null )]
        [TestCase( null, EmptyString )]
        [TestCase( EmptyString, EmptyString )]
        public void check_main_constructor_for_exceptions(string title, string author)
        {
            Assert.Throws<ArgumentException>( () => new DForm( title, author ) );
        }


        [Test]
        public void check_title_can_be_changed( )
        {
            Assert.NotNull( typeof( DForm ).GetProperty( "Title" ).GetSetMethod(), "Title Propery SHOULD be MODIFIABLE" );
        }

        [Test]
        public void check_author_cannot_be_changed()
        {
            Assert.That( typeof( DForm ).GetProperty( "Author" ).GetSetMethod(), Is.EqualTo( null ), "Author Property CANNOT be CHANGED!" );
        }

        [Test]
        public void check_created_and_last_modified_cannot_be_changed()
        {
            Assert.That( typeof( DForm ).GetProperty( "Created" ).GetSetMethod(), Is.EqualTo( null ), "Created Property CANNOT be CHANGED!" );
            Assert.That( typeof( DForm ).GetProperty( "LastModified" ).GetSetMethod(), Is.EqualTo( null ), "LastModified Property CANNOT be CHANGED!" );
        }

        [TestCase( "Title 1" )]
        [TestCase( "Title 2" )]
        [TestCase( "Title 3" )]
        [TestCase( "Super Title" )]
        public void check_title_is_changed( string title )
        {
            DForm form = new DForm();
            form.Title = title;
            Assert.That( form.Title, Is.EqualTo( title ) );
        }

        [TestCase( "Title 1" )]
        [TestCase( "Title 2" )]
        [TestCase( "Title 3" )]
        [TestCase( "Super Title" )]
        public void check_version_and_last_modified_are_updated_if_title_is_modified( string title )
        {
            DForm form = new DForm();
            DateTime previousLastModified = form.LastModified;
            int previousVersion = form.Version;
            Thread.Sleep( TimeSpan.FromMilliseconds( 1 ) );
            form.Title = title;
            Assert.That( form.Title, Is.EqualTo( title ) );
            Assert.That( form.LastModified, Is.GreaterThan( previousLastModified ), "Form LastModified = " + form.LastModified + " and Previous LastModified = " + previousLastModified );
            Assert.That( form.Version, Is.GreaterThan( previousVersion ), "Form Version = " + form.Version + " and Previous = " + previousVersion );
        }

    }
}
