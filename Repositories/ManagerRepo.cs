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
        private IWarehouseContract _warehouseContract;
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

        public IWarehouseContract warehouseContract
        {
            get
            {
                if (_warehouseContract == null)
                    _warehouseContract = new WarehouseRepo(_repoContext);
                return _warehouseContract;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
