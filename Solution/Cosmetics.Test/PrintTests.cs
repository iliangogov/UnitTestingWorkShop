using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Cosmetics.Products;
using Cosmetics.Common;

namespace Cosmetics.Test
{
    [TestFixture]
   public class PrintTests
    {
        [Test]
        //**Shampoo.Print()** should return a string with the shampoo details in the required format.
        public void ShampooPrintShouldReturnStringWithShampooDetailsInTheRequredFormat()
        {
            string name = "Elseve";
            string brand = "Loreal";
            decimal price = 20m;
            var gender = GenderType.Unisex;
            uint milliliters = 20;
            var usage = UsageType.EveryDay;
 
            var shampoo = new Shampoo(name,brand,price,gender,milliliters,usage);
            string expected = "- Loreal - Elseve:\r\n  * Price: $400\r\n  * For gender: Unisex\r\n  * Quantity: 20 ml\r\n  * Usage: EveryDay";
            string actual = shampoo.Print();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        //**Toothpaste.Print()** should return a string with the toothpaste details in the required format.
        public void ToothPastePrintShouldReturnStringWithToothPasteDetailsInTheRequredFormat()
        {
            string name = "Max";
            string brand = "Colgate";
            decimal price = 20m;
            var gender = GenderType.Unisex;
            var ingredientes = new List<string> { "water" };

            var paste = new Toothpaste(name, brand, price, gender, ingredientes);
            string expected = "- Colgate - Max:\r\n  * Price: $20\r\n  * For gender: Unisex\r\n  * Ingredients: water";
            string actual = paste.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}
