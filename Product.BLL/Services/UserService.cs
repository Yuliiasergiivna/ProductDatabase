using System;
using ProductLibrary.BLL.Mappers;
using ProductLibrary.Common;
using ProductLibrary.BLL.Entities;

namespace ProductLibrary.BLL.Services
{
    public class UserService : IUserRepository<ProductLibrary.BLL.Entities.User>
    {
        private readonly IUserRepository<ProductLibrary.DAL.Entities.User> _dalService;

        public UserService(IUserRepository<ProductLibrary.DAL.Entities.User> dalService)
        {
            _dalService = dalService;
        }

        public Guid CheckPassword(string email, string password)
        {
            return _dalService.CheckPassword(email, password);
        }

        public Guid Create(ProductLibrary.BLL.Entities.User entity)
        {
            return _dalService.Create(entity.ToDAL());
        }
    }
}