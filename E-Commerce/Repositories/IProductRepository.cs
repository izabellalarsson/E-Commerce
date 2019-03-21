using System;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product Get(int id);
        void Add(Product product);
    }
}
