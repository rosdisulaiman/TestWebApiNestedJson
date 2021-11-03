using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IScanRepository
    {
        //IEnumerable<ScanData> GetAllScannedData(bool trackChanges);
        Task<IEnumerable<ScanData>> GetAllScanAsync(bool trackChanges);
        //ScanData GetScanDataById(int scanId, bool trackChanges);
        Task<ScanData> GetScanAsync(int scanId, bool trackChanges);
        void AddScanData(ScanData scanData);
        void DeleteScanData(ScanData scanData);
    }
}
