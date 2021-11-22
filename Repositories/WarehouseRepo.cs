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
    public class WarehouseRepo:BaseRepo<Warehouse>,IWarehouseContract
    {
        private readonly RepoContext _repoContext;

        public WarehouseRepo(RepoContext repoContext):
            base(repoContext)
        {
            this._repoContext = repoContext ?? throw new ArgumentNullException(nameof(repoContext));
        }
    }
}
