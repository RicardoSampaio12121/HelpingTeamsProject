using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Extensions
    {
        public Data.Entities.ProductModel LogicProductAsDataProduct(this Logic.Entities.ProductModel product)
        {
            Data.Entities.ProductModel output = new()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity

            };
        }
    }
}
