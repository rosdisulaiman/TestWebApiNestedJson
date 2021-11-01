using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// Synchronous Method
    /// </summary>
    /// 
    public interface IEmployeeRepository
    {
        // with paging
        //Task<IEnumerable<Employee>> GetEmployeesAsync (Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

        //with paging : pagelist
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetEmployeeAsync (Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);

    }

    /// <summary>
    /// Synchronous Method
    /// </summary>
    /// 
    //public interface IEmployeeRepository
    //{
    //    IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    //    Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
    //    void CreateEmployeeForCompany(Guid companyId, Employee employee);
    //    void DeleteEmployee(Employee employee);
    //}
}
