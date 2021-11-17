using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ManagerRepo : IManagerContract
    {
        private readonly RepoContext _repoContext;
        private IUserContract _userContract;
        public ManagerRepo(RepoContext repoContext)
        {
            this._repoContext = repoContext ?? throw new ArgumentNullException(nameof(repoContext));
         
        }
        public IUserContract userContract
        {
            get
            {
                if (_userContract == null)
                    _userContract = new UserRepo(_repoContext);
                return _userContract;
            }
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
