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
    public class FaceRepository : RepositoryBase<Face>, IFaceRepository
    {
        public FaceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Face> GetFaces(int scanId, bool trackChanges) =>
            FindByCondition(e => e.ScanId.Equals(scanId), trackChanges).OrderBy(e => e.CreatedDate);
        public Face GetFaceById(int scanId, int id, bool trackChanges) => FindByCondition(e => e.ScanId.Equals(scanId) && e.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
