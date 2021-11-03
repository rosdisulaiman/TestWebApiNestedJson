using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Services
{
    public interface IScanRepository
    {
        Task<IEnumerable<ScanData>> GetAllSc();
        Task<ScanData> GetScById(int scanDataId);
        Task<ScanData> AddScData(ScanData scanData);
        Task<ScanData> DeleteSc(int scanDataId);
    }
}
