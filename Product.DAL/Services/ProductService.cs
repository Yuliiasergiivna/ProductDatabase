using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary.Common;
using ProductLibrary.DAL.Entities;
using System.Data;
using ProductLibrary.DAL.Mappers;

namespace ProductLibrary.DAL.Services
{
    public class ProductService : IProductRepository<Product>
    {
        private readonly SqlConnection _connection;
        public ProductService(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> Get()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Product_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.ToProduct();
                    }
                }
            }
        }
        public Product Get(int productId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Product_Get_ById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(productId), productId);
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var product = reader.ToProduct();
                        _connection.Close();
                        return product;
                    }
                }
            }
            throw new ArgumentOutOfRangeException(nameof(productId), "Le produit n'existe pas dans la base de données.");
        }
        public void Create(Product product)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Product_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Product.Name), product.Name);
                    command.Parameters.AddWithValue(nameof(Product.Description), (object?)product ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Product.CurrentPrice), product.CurrentPrice);
                    if (_connection.State == ConnectionState.Closed) _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open) _connection.Close();
                }
            }
        }
        public void Update(int productId, Product newData)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Product_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(productId), productId);
                command.Parameters.AddWithValue(nameof(Product.Name), newData.Name);
                command.Parameters.AddWithValue(nameof(Product.Description), (object?)newData.Description ?? DBNull.Value);
                command.Parameters.AddWithValue(nameof(Product.CurrentPrice), newData.CurrentPrice);
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                command.ExecuteNonQuery();
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }
        }
        public void Delete(int productId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Product_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(productId), productId);
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                command.ExecuteNonQuery();
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }
        }
        public void AddStock(int productId, int quantity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_StockEntry_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(StockEntry.EntryDate), DateTime.Now);
                command.Parameters.AddWithValue(nameof(StockEntry.StockOperation), quantity);
                command.Parameters.AddWithValue(nameof(StockEntry.ProductId), productId);
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                command.ExecuteNonQuery();
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }
        }
    }

}
