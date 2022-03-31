using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;

namespace VarlikZimmetDepoYonetimi.Core.IRepositories
{
    public interface IAuthRepository
    {
        Task<LoginInfo> Register(LoginInfo user, string password);
        Task<LoginInfo> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
