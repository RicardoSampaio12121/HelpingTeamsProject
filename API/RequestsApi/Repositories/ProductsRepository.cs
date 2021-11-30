/*
 * This file contains all the methods to access the database tables related to the products
 */
using MySql.Data.MySqlClient;
using RequestsApi.Dtos;
using RequestsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsApi.Repositories
{
    /// <summary>
    /// Repository to manage some functions that only the people responsible for the shipping of products can access
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        //TODO: Take the connection string to a secure place
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";
        //private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=claudio;Pwd=cmffs1810;";

        /// <summary>
        /// Gets all the available products in tha database
        /// </summary>
        /// <returns>
        /// IEnumerable of available products
        /// </returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var con = new MySqlConnection(ProductsRepository.con);
            const string sql = "SELECT * FROM available_products";
            List<Product> output = new();

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
                
            while (await sqlDr.ReadAsync())
            {
                output.Add(new Product()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    Name = sqlDr[1].ToString(),
                    Quantity = int.Parse(sqlDr[2].ToString()),
                    UnitPrice = float.Parse(sqlDr[3].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        /// <summary>
        /// Gets the information of a product by its id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GatherProductAsync(int productId)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM available_products WHERE id = '{productId}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
            await sqlDr.ReadAsync();
            
            var output = new Product()
            {
                Id = sqlDr.GetInt32(0),
                Name = sqlDr.GetString(1),
                Quantity = sqlDr.GetInt32(2),
                UnitPrice = sqlDr.GetFloat(3)
            };
            return output;
        }

        /// <summary>
        /// Gets the information of a product by its name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public async Task<Product> GatherProductByNameAsync(string productName)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM available_products WHERE name = '{productName}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
            await sqlDr.ReadAsync();

            var output = new Product()
            {
                Id = sqlDr.GetInt32(0),
                Name = sqlDr.GetString(1),
                Quantity = sqlDr.GetInt32(2),
                UnitPrice = sqlDr.GetFloat(3)
            };

            return output;
        }

        /// <summary>
        /// Creates a prpduct in the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task CreateProduct(CreateProductDto product)
        {
            MySqlConnection con = new(ProductsRepository.con);
            const string sql =
                "INSERT INTO available_products (name, quantity, unit_price) VALUE (@name, @quantity, @price)";
            
            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();

            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = product.Name;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = product.Quantity;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = product.price;

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Adds stock to a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task AddStock(int id, int quantity)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql =
               $"UPDATE available_products SET quantity = quantity + @toAdd WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);

            cmd.Parameters.Add("@toAdd", MySqlDbType.Int32).Value = quantity;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        
        /// <summary>
        /// Gets the Id, price and quantity of a product
        /// </summary>
        /// <param name="reqId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IdPriceQuantityModel>> GetIdPriceQuantity(int reqId)
        {
            List<IdPriceQuantityModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"select ap.unit_price as prodPrice, prp.product_id AS prodId, prp.quantity AS prodQuantity from available_products ap inner join pending_requests_products prp ON prp.product_id = ap.id and prp.pending_request_id = @reqId";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@reqId", MySqlDbType.Int32).Value = reqId;

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new IdPriceQuantityModel()
                {
                    price = float.Parse(sqlDr[0].ToString()),
                    id = int.Parse(sqlDr[1].ToString()),
                    quantity = int.Parse(sqlDr[2].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }
        
        /// <summary>
        /// Updates the stock of a product in the database
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <returns></returns>
        public async Task UpdateProductsQuantity(List<UpdateProductsQuantityDto> toUpdate)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql =
               $"UPDATE available_products SET quantity = quantity - @toTake WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            
            foreach (var values in toUpdate)
            {
                cmd.Parameters.Add("@toTake", MySqlDbType.Int32).Value = values.quantityToTake;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = values.prodId;
                
                await cmd.ExecuteNonQueryAsync();
                cmd.Parameters.Clear();
            }
            await con.CloseAsync();
        }
    }
}