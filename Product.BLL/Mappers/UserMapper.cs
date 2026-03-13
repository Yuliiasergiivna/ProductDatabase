using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary.BLL.Entities;
using ProductLibrary.DAL.Entities;



using System.ComponentModel;

namespace ProductLibrary.BLL.Mappers
{
    public static class UserMapper
    {
        public static BLL.Entities.User ToBLL(this DAL.Entities.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.User(
                entity.UserId,
                entity.Email,
                entity.Password
                );
        }
        public static DAL.Entities.User ToDAL(this BLL.Entities.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Entities.User()
            {
                UserId = entity.UserId,
                Email = entity.Email,
                Password = entity.Password
            };
        }
    }
    
}
