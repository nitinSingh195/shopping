using shoppingCart.Model;
using System.Data.SqlClient;
using System.Data;

namespace shoppingCart.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly string connectionString;
        private readonly IConfiguration iconfiguration;
        public ProductsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            iconfiguration = configuration;
        }
        public List<Product> GetProducts()
        
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                ProductImage = reader.GetString(2),
                                ProductDescription = reader.GetString(3),
                                ProductPrice = reader.GetDecimal(4),
                                DiscountedPrice = reader.GetDecimal(5)
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

    }
}
