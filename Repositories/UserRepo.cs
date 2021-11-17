using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepo:BaseRepo<User>,IUserContract
    {
        private readonly RepoContext _repoContext;

        public UserRepo(RepoContext repoContext)
            :base(repoContext)
        {
            this._repoContext = repoContext;
        }

        public  User GetById(int id)
        {
            return _repoContext.Users.FirstOrDefault(x=>x.Id == id);
        }
    }
}
