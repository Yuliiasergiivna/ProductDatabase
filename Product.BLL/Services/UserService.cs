using ProductLibrary.BLL.Entities;
using ProductLibrary.BLL.Mappers;
using ProductLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.BLL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly IUserRepository<DAL.Entities.User> _dalService;

        public UserService(IUserRepository<DAL.Entities.User> dalService)
        {
            _dalService = dalService;
        }

        public Guid CheckPassword(string email, string password)
        {
            return _dalService.CheckPassword( email, password);
        }

        public Guid Create(User entity)
        {
            return _dalService.Create(entity.ToDAL());
        }
    }
}
