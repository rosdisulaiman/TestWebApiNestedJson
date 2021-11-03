﻿using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
 

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

       

     
        /// <summary>
        /// Synchronous Method
        /// </summary>
        /// 
        //public void Save() => _repositoryContext.SaveChanges();


        /// <summary>
        /// ASynchronous Method
        /// </summary>
        ///
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        //public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
