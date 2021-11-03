using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data;
using TestApi.Models;

namespace TestApi.Services
{
    public class ScanRepository : IScanRepository
    {
        private readonly AppDbContext _appDbContext;

        public ScanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ScanData> AddScData(ScanData scanData)
        {

            var result = await _appDbContext.ScanDatas.AddAsync(scanData);
            
            await _appDbContext.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<ScanData> DeleteSc(int scanDataId)
        {
            var result = await _appDbContext.ScanDatas
                .FirstOrDefaultAsync(s => s.ScanId == scanDataId);
            if (result != null)
            {
                _appDbContext.ScanDatas.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ScanData>> GetAllSc()
        {
            return await _appDbContext.ScanDatas.ToListAsync();
        }

        public async Task<ScanData> GetScById(int scanDataId)
        {
            return await _appDbContext.ScanDatas
                .Include(e => e.Faces)
                //       .ThenInclude(e => e.skill) method to add more data from other table as many as needed
                .FirstOrDefaultAsync(e => e.ScanId == scanDataId);
        }
    }
}
