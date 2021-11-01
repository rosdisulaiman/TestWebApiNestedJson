using AutoMapper;
using CARAAPI.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using System.Text.Json;
using CARAAPI.Utility;

namespace CARAAPI.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        //private readonly IDataShaper<EmployeeDto> _dataShaper;
        private readonly EmployeeLinks _employeeLinks;

        public EmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, /*IDataShaper<EmployeeDto> dataShaper,*/ EmployeeLinks employeeLinks)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            //_dataShaper = dataShaper;
            _employeeLinks = employeeLinks;
        }

        /// <summary>
        /// Synchronous Method
        /// </summary>
        [HttpGet]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        //For paging
        //public async Task <IActionResult> GetEmployeesForCompany(Guid companyId)
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            

            if (!employeeParameters.ValidAgeRange) return BadRequest("Max age can't be less than min age.");

            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            //for paging
            //var employeesFromDb = await _repository.Employee.GetEmployeesAsync(companyId, trackChanges: false);
            var employeesFromDb = await _repository.Employee.GetEmployeesAsync(companyId, employeeParameters, trackChanges: false);


            //with pagelist
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(employeesFromDb.MetaData));

            //return Ok(employeesFromDb);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

            //return Ok(_dataShaper.ShapeData(employeesDto, employeeParameters.Fields));
            var links = _employeeLinks.TryGenerateLinks(employeesDto, employeeParameters.Fields, companyId, HttpContext);

            return links.HasLinks ? Ok(links.LinkedEntities) : Ok(links.ShapedEntities);
        }

        [HttpGet("{id}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges: false);
            if (employeeDb == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeDto>(employeeDb);

            return Ok(employee);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {

            /// <summary>
            /// add filter attribute remove code
            //if (employee == null)
            //{
            //    _logger.LogError("EmployeeForCreationDto object send from client is null.");
            //    return BadRequest("EmployeeForCreationDto object is null.");
            //}
            //if (!ModelState.IsValid)
            //{
            //    _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
            //    return UnprocessableEntity(ModelState);
            //}

            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeeEntity = _mapper.Map<Employee>(employee);

            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid Id)
        {
            /// <summary>
            /// add filteremployee exist attribute remove code
            //var company =await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
            //    return NotFound();
            //}

            //var employeeForCompany = await _repository.Employee.GetEmployeeAsync(companyId, Id, trackChanges: false);
            //if (employeeForCompany == null)
            //{
            //    _logger.LogInfo($"Employee with id: {Id} doesn't exist in database.");
            //    return NotFound();
            //}


            //add action filter
            var employeeForCompany = HttpContext.Items["employee"] as Employee;

            _repository.Employee.DeleteEmployee(employeeForCompany);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            /// <summary>
            ///// add filter attribute remove code
            //if (employee == null)
            //{
            //    _logger.LogError("EmployeeForUpdateDto object sent from client is null.");
            //    return BadRequest("EMployeeForUpdateDto object is null.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    _logger.LogError("Invalid model state for the EmployeeForUpdateDto object");
            //    return UnprocessableEntity(ModelState);
            //}


            /// <summary>
            /// add filteremployee exist attribute remove code
            //var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
            //    return NotFound();
            //}

            //var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges: true);
            //if (employeeEntity == null)
            //{
            //    _logger.LogInfo($"Employee with id: {id} doesn't exist in database.");
            //    return NotFound();
            //}

            //add action filter
            var employeeEntity = HttpContext.Items["employee"] as Employee;

            _mapper.Map(employee, employeeEntity);
            await _repository.SaveAsync();

            return NoContent();
        }


        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(Guid companyID, Guid id,
            [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null.");
            }

            //add action filter
            var employeeEntity = HttpContext.Items["employee"] as Employee;

            /// <summary>
            /// add filteremployee exist attribute remove code
            //var company = await _repository.Company.GetCompanyAsync(companyID, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {companyID} doesn't exit in the database.");
            //    return NotFound();
            //}

            //var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyID, id, trackChanges: true);
            //if (employeeEntity == null)
            //{
            //    _logger.LogInfo($"Employee with id : {id} doesn't exist in the database.");
            //    return NotFound();
            //}

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            patchDoc.ApplyTo(employeeToPatch, ModelState);

            TryValidateModel(employeeToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// Synchronous Method
        /// </summary>
        //[HttpGet]
        //public IActionResult GetEmployeesForCompany(Guid companyId)
        //{
        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges: false);
        //    //return Ok(employeesFromDb);
        //    var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        //    return Ok(employeesDto);
        //}

        ////[HttpGet("{id}")]
        //[HttpGet("{id}", Name = "GetEmployeeForCompany")]
        //public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        //{
        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges: false);
        //    if (employeeDb == null)
        //    {
        //        _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employee = _mapper.Map<EmployeeDto>(employeeDb);

        //    return Ok(employee);
        //}

        //[HttpPost]
        //public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        //{
        //    if (employee == null)
        //    {
        //        _logger.LogError("EmployeeForCreationDto object send from client is null.");
        //        return BadRequest("EmployeeForCreationDto object is null.");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
        //        return UnprocessableEntity(ModelState);
        //    }

        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employeeEntity = _mapper.Map<Employee>(employee);

        //    _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
        //    _repository.Save();

        //    var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
        //    return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id}, employeeToReturn);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteEmployeeForCompany (Guid companyId, Guid Id)
        //{
        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employeeForCompany = _repository.Employee.GetEmployee(companyId, Id, trackChanges: false);
        //    if (employeeForCompany == null)
        //    {
        //        _logger.LogInfo($"Employee with id: {Id} doesn't exist in database.");
        //        return NotFound();
        //    }

        //    _repository.Employee.DeleteEmployee(employeeForCompany);
        //    _repository.Save();

        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateEmployeeForCompany (Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        //{
        //    if (employee == null)
        //    {
        //        _logger.LogError("EmployeeForUpdateDto object sent from client is null.");
        //        return BadRequest("EMployeeForUpdateDto object is null.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("Invalid model state for the EmployeeForUpdateDto object");
        //        return UnprocessableEntity(ModelState);
        //    }

        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employeeEntity = _repository.Employee.GetEmployee(companyId, id, trackChanges: true);
        //    if (employeeEntity == null)
        //    {
        //        _logger.LogInfo($"Employee with id: {id} doesn't exist in database.");
        //        return NotFound();
        //    }

        //    _mapper.Map(employee, employeeEntity);
        //    _repository.Save();

        //    return NoContent();
        //}

        //[HttpPatch("{id}")]
        //public IActionResult PartiallyUpdateEmployeeForCompany(Guid companyID, Guid id, 
        //    [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        //{
        //    if (patchDoc == null)
        //    {
        //        _logger.LogError("patchDoc object sent from client is null.");
        //        return BadRequest("patchDoc object is null.");
        //    }

        //    var company = _repository.Company.GetCompany(companyID, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyID} doesn't exit in the database.");
        //        return NotFound();
        //    }

        //    var employeeEntity = _repository.Employee.GetEmployee(companyID, id, trackChanges: true);
        //    if (employeeEntity == null)
        //    {
        //        _logger.LogInfo($"Employee with id : {id} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

        //    patchDoc.ApplyTo(employeeToPatch, ModelState);

        //    TryValidateModel(employeeToPatch);

        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("Invalid model state for the patch document");
        //        return UnprocessableEntity(ModelState);
        //    }

        //    _mapper.Map(employeeToPatch, employeeEntity);

        //    _repository.Save();

        //    return NoContent();
        //}
    }
}
