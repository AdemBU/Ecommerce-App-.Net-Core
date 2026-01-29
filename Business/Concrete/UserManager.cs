using Business.Abstract;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var hashedPassword = SecurityHelper.HashPassword(password);
            var users = await _userDal.GetAllAsync();
            return users.FirstOrDefault(x => x.UserName == username && x.PasswordHash == hashedPassword);
        }

        public async Task CreateUserAsync(User user, string plainPassword)
        {
            user.PasswordHash = SecurityHelper.HashPassword(plainPassword);
            await _userDal.AddAsync(user);
        }
    }
}
