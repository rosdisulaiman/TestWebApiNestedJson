using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ScanRepository : RepositoryBase<ScanData>, IScanRepository
    {
        

        public ScanRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
           
        }

        public IEnumerable<ScanData> GetAllScannedData(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.LoggedDate).ToList();

        public ScanData GetScanDataById(int scanId, bool trackChanges) => FindByCondition(s => s.Id.Equals(scanId), trackChanges).SingleOrDefault();

        public void AddScanData(ScanData scanData) => Create(scanData);
    }
        
}
