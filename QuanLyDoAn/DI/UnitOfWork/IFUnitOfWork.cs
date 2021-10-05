using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyDoAn.DI.UnitOfWork
{
    public interface IFUnitOfWork 
    {
        int SaveChange();

        /// <summary>
        /// Async SaveChange
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangeAsync();
    }
}
