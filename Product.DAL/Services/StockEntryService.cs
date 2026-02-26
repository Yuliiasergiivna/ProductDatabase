using Microsoft.Data.SqlClient;
using ProductLibrary.Common;
using ProductLibrary.DAL.Entities;
using ProductLibrary.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.DAL.Services
{
    public class StockEntryService : IStockRepository<Entities.StockEntry>
    {
        private readonly SqlConnection _connection;

        public StockEntryService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(StockEntry entity)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_StockEntry_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue(nameof(StockEntry.StockEntryId), entity.StockEntryId);
                    command.Parameters.AddWithValue(nameof(StockEntry.EntryDate), entity.EntryDate);
                    command.Parameters.AddWithValue(nameof(StockEntry.StockOperation), entity.StockOperation);
                    command.Parameters.AddWithValue(nameof(StockEntry.ProductId), entity.ProductId);
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

        public void Delete(int productId)
        {
          using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_StockEntry_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(productId), productId);
               if (_connection.State == ConnectionState.Closed) _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<StockEntry> Get()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_StockEntry_Get_All";
                command.CommandType = CommandType.StoredProcedure;
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.ToStockEntry();
                    }
                }
            }
        }

        public Entities.StockEntry? Get(int productId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_StockEntry_Get_ById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(StockEntry.ProductId), productId);
                    if (_connection.State == ConnectionState.Closed) _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToStockEntry();
                        }
                        throw new ArgumentOutOfRangeException(nameof(productId));
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open) _connection.Close();
                }
            }
        }
        public void Update(int stockEntryId, StockEntry newData)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {

                command.CommandText = "SP_StockEntry_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(stockEntryId), stockEntryId);
                command.Parameters.AddWithValue(nameof(StockEntry.EntryDate), newData.EntryDate);
                command.Parameters.AddWithValue(nameof(StockEntry.StockOperation), newData.StockOperation);
                command.Parameters.AddWithValue(nameof(StockEntry.ProductId), newData.ProductId);
                if (_connection.State == ConnectionState.Closed) _connection.Open();
                command.ExecuteNonQuery();
                if (_connection.State == ConnectionState.Open) _connection.Close();
            }
        }
    }
    
}
