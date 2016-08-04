using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Engine;

namespace Cosmetics.Test
{
    internal class FakeEngine : CosmeticsEngine
    {
        public FakeEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart) 
            : base(factory, shoppingCart)
        {
        }
        internal IDictionary<string, ICategory> BaseCategories
        {
            get
            {
                return base.categories;
            }
        }

        internal IDictionary<string, IProduct> BaseProducts
        {
            get
            {
                return base.products;
            }
        }
    }
}
