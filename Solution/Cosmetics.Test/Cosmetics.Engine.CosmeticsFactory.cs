using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Cosmetics.Common;
using Cosmetics.Engine;
using Cosmetics.Products;
using Cosmetics.Contracts;

namespace Cosmetics.Test
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [Test]
        //**CreateShampoo** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)  
        public void CreateShampooShouldThrowArgumentNullExceptionWhenThePassedNameParameterIsInvalidNullOrEmptyOrWithLengthOutOfRange()
        {
            string name = string.Empty;
            string brand = "brand";
            decimal price = 20m;
            var gender = GenderType.Unisex;
            uint milliliters = 20;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [Test]
        //**CreateShampoo** should throw **ArgumentNullException**, when the passed "brand" parameter is invalid. (Null or Empty, or with length out of range)
        public void CreateShampooShouldThrowArgumentNullExceptionWhenThePassedBrandParameterIsInvalidNullOrEmptyOrWithLengthOutOfRange()
        {
            string name = "Colgate";
            string brand = String.Empty;
            decimal price = 20m;
            var gender = GenderType.Unisex;
            uint milliliters = 20;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [Test]
        //**CreateShampoo** should return a **new Shampoo**, when the passed parameters are all valid.
        public void CreateShampooShouldReturnNewShampooWhenThePassedParametersAreInValidFormat()
        {
            string name = "Elseve";
            string brand = "Loreal";
            decimal price = 20m;
            var gender = GenderType.Unisex;
            uint milliliters = 20;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();
            var shampoo = factory.CreateShampoo(name, brand, price, gender, milliliters, usage);

            //  Assert.IsTrue(shampoo is IShampoo);
            //  Assert.IsNotNull(shampoo.GetType().GetInterface("IShampoo"));
            Assert.IsInstanceOf(typeof(Shampoo), shampoo);
        }

        [Test]
        //**CreateCategory** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)
        public void CreateCategoryShouldThrowWhenThePassedNameIsInvalid()
        {
            string name = String.Empty;

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));

        }

        [Test]
        //**CreateCategory** should return a **new Category**, when the passed parameters are all valid. 
        public void CreateCategoryShouldReturnNewCategoryWhenThePassedParametersAreAllValid()
        {
            string name = "Body care";

            var factory = new CosmeticsFactory();
            var category = factory.CreateCategory(name);

            Assert.IsInstanceOf(typeof(Category), category);
        }

        [Test]
        //**CreateToothpaste** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)
        public void CreateToothpasteShouldThrowWhenThePassedNameParameterIsInvalid()
        {
            string name = null;
            string brand = "Colgate";
            decimal price = 20m;
            var gender = GenderType.Unisex;
            var ingredientes = new List<string> { "water", "calcium", "soda" };

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, brand, price, gender, ingredientes));
        }

        [Test]
        // **CreateToothpaste** should throw **ArgumentNullException**, when the passed "brand" parameter is invalid. (Null or Empty, or with length out of range)
        public void CreateToothpasteShouldThrowWhenThePassedBrandParameterIsInvalid()
        {
            string name = "Max White";
            string brand = null;
            decimal price = 20m;
            var gender = GenderType.Unisex;
            var ingredientes = new List<string> { "water", "calcium", "soda" };

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, brand, price, gender, ingredientes));
        }

        [Test]
        //**CreateToothpaste** should throw **IndexOutOfRangeException**, when the count of items in the list of ingredients is not in the allowed boundaries.
        public void CreateToothpasteShouldThrowWhentheCountOfItemsInTheListOfIngredients()
        {
           // int MinLengthIngredient = 4;
           // int MaxLengthIngredient = 12;
            string name = "Max White";
            string brand = "Colgate";
            decimal price = 20m;
            var gender = GenderType.Unisex;
            var ingredientes = new List<string> { "W", "calcium", "soda" };

            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, brand, price, gender, ingredientes));
        }

        [Test]
        //**CreateShoppingCart** should always return a new **ShoppingCart**
        public void CreateShoppingCartShouldAlwaysReturnNewShoppingCart()
        {
            var cart1 = new ShoppingCart();
            var cart2 = new ShoppingCart();

            Assert.AreNotSame(cart1, cart2);
        }

        [Test]
        public void CreateShappingCart_ShouldReturnANewShoppingCart()
        {
            var factory = new CosmeticsFactory();

            var category = factory.CreateShoppingCart();
            
            Assert.IsNotNull(category.GetType().GetInterface("IShoppingCart"));
        }
    }
}
