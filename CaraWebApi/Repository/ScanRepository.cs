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

        //public IEnumerable<ScanData> GetAllScannedData(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.LoggedDate).ToList();
        public async Task<IEnumerable<ScanData>> GetAllScanAsync(bool trackChanges)
        //=> await FindAll(trackChanges).OrderBy(c => c.LoggedDate).ToListAsync();
        {
            return await FindAll(trackChanges).OrderBy(c => c.LoggedDate).ToListAsync();
        }

        //public ScanData GetScanDataById(int scanId, bool trackChanges) => FindByCondition(s => s.Id.Equals(scanId), trackChanges).Include(x => x.Faces).SingleOrDefault(e => e.Id == scanId);
        //public ScanData GetScanDataById(int scanId, bool trackChanges) => FindByCondition(s => s.Id.Equals(scanId), trackChanges).SingleOrDefault();
        public async Task<ScanData> GetScanAsync(int scanId, bool trackChanges)
        {
            return await FindByCondition(sd => sd.Id.Equals(scanId), trackChanges)
                .SingleOrDefaultAsync();
        }
            //=> await FindByCondition(sd => sd.Id.Equals(scanId), trackChanges)
            //.SingleOrDefaultAsync();
        
        public void AddScanData(ScanData scanData) => Create(scanData);

        public void DeleteScanData(ScanData scanData)
        {
            Delete(scanData);
        }

    }        
}
