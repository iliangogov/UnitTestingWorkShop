using System;
using NUnit.Framework;
using Cosmetics.Common;

namespace Cosmetics.Test
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test]
        //**CheckIfNull** should throw **NullReferenceException**, when the parameter **"obj"** is null.  
        public void CheckIfNull_ShouldThrowNullReferenceException_WhenTheParameterObjIsNull()
        {
            object obj = null;
            string str = "anyString";

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj, str));
        }

        [Test]
        //**CheckIfNull** should **NOT throw** any Exceptions, when the parameter **"obj"** is NOT null.   
        public void CheckIfNull_ShouldNotThrowNullReferenceException_WhenTheParameterObjIsNotNull()
        {
            object obj = "x";
            string str = "y";
           Assert.DoesNotThrow(()=> Validator.CheckIfNull(obj, str));
        }

        //**CheckIfStringIsNullOrEmpty** should throw **NullReferenceException**, when the parameter **"text"** is null or empty.
        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenTheParameterTextIsNull()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null));
        }

        //**CheckIfStringIsNullOrEmpty** should **NOT throw** any Exceptions, when the parameter **"text"** is NOT null or empty. 
        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrowNullReferenceException_WhenTheParameterTextIsNotNull()
        {
            string text = "x";
            string str = "y";
            Assert.DoesNotThrow(()=> Validator.CheckIfStringIsNullOrEmpty(text, str));
        }

        //**CheckIfStringLengthIsValid** should throw **IndexOutOfRangeException**, when the length of the parameter **"text"** is lower than the minimum allowed value or greater than the maximum allowed value.
        [Test]
        [TestCase("text", 3, 2)]
        [TestCase("text", 20, 10)]
        public void CheckIfStringLengthIsValidShouldThrowIndexOutOfRangeExceptionWhenTheLengthOfTheParameterTextIsLowerThanTheMinimumAllowedValueOrGreaterThanTheMaximumAllowedValue(string text, int max, int min , string message = null)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text,max,min));
        }

        //- **CheckIfStringLengthIsValid** should **NOT throw** any Exceptions, when the length of the parameter "text" is in the allowed boundaries.
        [Test]
        [TestCase("text", 5, 2)]
        [TestCase("text", 20, 1)]
        public void CheckIfStringLengthIsValidShouldNotThrowIndexOutOfRangeExceptionWhenTheLengthOfTheParameterTextIsWithCorrectLength(string text, int max, int min, string message = null)
        {
           Assert.DoesNotThrow(()=> Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}