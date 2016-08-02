using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using Moq;
using Cosmetics.Contracts;
using Cosmetics.Engine;

namespace Cosmetics.Test
{
    [TestFixture]
    public class CosmeticsEngineTest
    {
        [Test]
        //**Start** should throw **ArgumentNullException**, when the "input" string of commands is not in the correct format.
        public void StartShouldThrowArgumentNullExceptionWhenTheInputStringOfCommandsIsNotInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("fakeCommand \r\n\r\n"));
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();

            var engine = new CosmeticsEngine(mockFactory.Object, mockCart.Object);

            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        //- **Start** should read, parse and execute **"CreateCategory" command**, when the passed input string is in the format that represents a CreateCategory command, which should result in adding the new Category in the list of categories.
        public void StartShouldCreateANewCategoryWhenInputIsInAValidFormat()
        {
            Console.SetIn(new StringReader("CreateCategory ForMale\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockFactory.Setup(factory => factory.CreateCategory(It.IsAny<string>())).Returns(new Mock<ICategory>().Object);

            engine.Start();

            mockFactory.Verify(mock => mock.CreateCategory(It.IsAny<string>()), Times.Once());
        }

    }
}
