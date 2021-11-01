using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFaceRepository
    {
        //Task<IEnumerable<Face>> Search(string name, string devno);
        //Task<IEnumerable<Face>> GetAllFc();
        //Task<Face> GetFcById(int faceId);
        //Task<Face> AddFcData(Face face);
        //Task<Face> DeleteFc(int faceId);
        IEnumerable<Face> GetFaces(int scanId, bool trackChanges);
        Face GetFaceById(int scanId, int id, bool trackChanges);
    }
}
