using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IScanRepository ScanData { get; }
        IFaceRepository FaceData { get; }

        /// <summary>
        /// ASynchronous Method
        /// </summary>
        ///
        Task SaveAsync();



        /// <summary>
        /// Synchronous Method
        /// </summary>
        ///
        //void Save();
    }
}
