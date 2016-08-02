using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Cosmetics.Engine;

namespace Cosmetics.Test
{
    [TestFixture]
    public class CommandTest
    {
        //**Parse** should **return new Command**, when the "input" string is in the required valid format.
        [Test]
        public void ParseShouldReturn_NewCommand_WhenTheInputStringIsInItheRequiredValidFormat()
        {
           var command= Command.Parse("xxx y");
            Assert.IsInstanceOf(typeof(Command), command);
        }
        [Test]
        //**Parse** should set correct values to the newly returned Command object's Properties ("Name" & "Parameters"), when the "input" string is in the valid required format.
        public void ParseShouldSetCorrectValuesToTheNewlyReturnedCommandObjectPropertiesNameParametersWhenTheInputStringIsInTheValidRequiredFormat()
        {
            var test=Command.Parse("xxx y z");
            Assert.AreEqual(test.Name, "xxx");
            Assert.AreEqual(test.Parameters.IndexOf("y"),0);
            Assert.AreEqual(test.Parameters.IndexOf("z"), 1);
        }

        [Test]
        //**Parse** should throw **ArgumentNullException** with a message that contains the string "Name", when the "input" string that represents the Command Name is Null Or Empty. 
        public void ParseShouldThrowArgumentNullExceptionWithMessageThatContainsTheStringNameWhenTheInputStringThatRepresentsTheCommandNameIsNullOrEmpty()
        {
            string expected = "Name";
            var actual= Assert.Throws<ArgumentNullException>(() => Command.Parse(String.Empty)).Message;
            StringAssert.Contains(expected, actual);
        }

        //**Parse** should throw **ArgumentNullException** with a message that contains the string "List", when the "input" string that represents the Command Parameters is Null or Empty.
        [Test]
        public void ParseShouldThrowArgumentNullExceptionWithMessageThatContainsTheStringListWhenTheInputStringThatRepresentsTheCommandParametersIsNullOrEmpty ()
        {
            string expected = "List";
            var actual = Assert.Throws<ArgumentNullException>(() => Command.Parse("xxx ")).Message;
            StringAssert.Contains(expected, actual);
        }
    }
}
