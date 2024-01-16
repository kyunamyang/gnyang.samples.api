using gnyang.samples.domain.Entities;
using gnyang.samples.infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace gnyang.samples.infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        void Commit();
        void Rollback();
    }
}
