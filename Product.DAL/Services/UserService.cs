using Microsoft.Data.SqlClient;
using ProductLibrary.Common;
using ProductLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.DAL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly SqlConnection _connection;

        public UserService(SqlConnection connection)
        {
            _connection = connection;
        }

        public Guid CheckPassword(string email, string password)
        {
           using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_CheckPassword";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(email), email);
                command.Parameters.AddWithValue(nameof(password), Encoding.UTF8.GetBytes(password));
                _connection.Open();
                object result = command.ExecuteScalar();
                _connection.Close();

                return result is Guid guid ? guid : Guid.Empty;
            }
        }

        public Guid Create(User entity)
        {
            using (SqlCommand command = _connection.CreateCommand()) 
            { 
                command.CommandText = "SP_User_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(User.Email), entity.Email);
                command.Parameters.AddWithValue(nameof(User.Password), Encoding.UTF8.GetBytes(entity.Password));
                _connection.Open();
                var result = command.ExecuteScalar();
                _connection.Close();

                return (Guid)result;
            }
        }
    }
}
