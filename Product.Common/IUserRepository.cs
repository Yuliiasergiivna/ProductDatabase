using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary.Common
{
    public interface IUserRepository<TUser>
    {
        public Guid Create ( TUser entity );
        public Guid CheckPassword ( string email, string password );

     }
}
