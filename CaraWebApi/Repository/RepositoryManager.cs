using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IScanRepository _scanRepository;
        private IFaceRepository _faceRepository;
 

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }

        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);

                return _companyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);

                return _employeeRepository;
            }
        }

        public IScanRepository ScanData
        {
            get
            {
                if (_scanRepository == null)
                    _scanRepository = new ScanRepository(_repositoryContext);

                return _scanRepository;
            }
        }

        public IFaceRepository FaceData
        {
            get
            {
                if (_faceRepository == null)
                    _faceRepository = new FaceRepository(_repositoryContext);

                return _faceRepository;
            }
        }

        /// <summary>
        /// Synchronous Method
        /// </summary>
        /// 
        public void Save() => _repositoryContext.SaveChanges();


        /// <summary>
        /// ASynchronous Method
        /// </summary>
        ///
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        //public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
