﻿using shoppingCart.Model;

namespace shoppingCart.Repository
{
    public interface IProductsRepository
    {

        public List<Product> GetProducts();

    }
}