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
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            var engine = new CosmeticsEngine(mockedFactory.Object, mockedCart.Object);

            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        //- **Start** should read, parse and execute **"CreateCategory" command**, when the passed input string is in the format that represents a CreateCategory command, which should result in adding the new Category in the list of categories.
        public void StartShouldCreateANewCategoryWhenInputIsInAValidFormat()
        {
            Console.SetIn(new StringReader("CreateCategory Body\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngine(mockedFactory.Object, mockedCart.Object);

            mockedFactory.Setup(factory => factory.CreateCategory(It.IsAny<string>())).Returns(new Mock<ICategory>().Object);

            engine.Start();

            mockedFactory.Verify(factory => factory.CreateCategory(It.IsAny<string>()), Times.Once());
        }

        [Test]
        //**Start** should read, parse and execute **"AddToCategory" command**, when the passed input string is in the format that represents a AddToCategory command, which should result in adding the selected product in the respective category.   
        public void StartShouldAddToCategoryWhenInputIsInAValidFormat()
        {
            Console.SetIn(new StringReader("AddToCategory Body Shampoo\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedCart = new Mock<IShoppingCart>();
            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            var engine = new FakeEngine(mockedFactory.Object, mockedCart.Object);

            mockedCategory.Setup(category => category.AddCosmetics(It.IsAny<IProduct>()));
            engine.BaseCategories.Add("Body", mockedCategory.Object);
            engine.BaseProducts.Add("Shampoo", mockedProduct.Object);
            engine.Start();

            mockedCategory.Verify(category => category.AddCosmetics(It.IsAny<IProduct>()), Times.Once());

        }
    }
}
