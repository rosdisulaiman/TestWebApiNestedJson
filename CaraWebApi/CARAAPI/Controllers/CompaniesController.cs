using AutoMapper;
using CARAAPI.ActionFilters;
using CARAAPI.ModelBinders;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARAAPI.Controllers
{
    //[ApiVersion("1.0")]
    [Route("api/companies")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")] // cache-store direct all
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) 
        { 
            _repository = repository;
            _logger = logger;
            _mapper = mapper; 
        }


        [HttpOptions] 
        public IActionResult GetCompaniesOptions() 
        { 
            Response.Headers.Add("Allow", "GET, OPTIONS, POST"); 
            return Ok(); 
        }

        
        //[HttpGet(Name = "GetCompanies"), Authorize]
        /// <summary> 
        /// Gets the list of all companies 
        /// </summary> 
        /// <returns>The companies list</returns>
        [HttpGet(Name = "GetCompanies"), Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges: false);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return Ok(companiesDto);
        }

        [HttpGet("{id}", Name = "CompanyById")]
        //[ResponseCache(Duration = 60)] // cache-store direct
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)] // resource level configuration
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _repository.Company.GetCompanyAsync(id, trackChanges: false);
            if (company == null) 
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            } 
            else 
            {
                var companyDto = _mapper.Map<CompanyDto>(company);
                return Ok(companyDto);
            }
        }

        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            { _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            
            var companyEntities = await _repository.Company.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != companyEntities.Count()) 
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            } 
            
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            
            return Ok(companiesToReturn);
        }

        /// <summary> 
        /// Creates a newly created company 
        /// </summary> 
        /// <param name="company"></param> 
        /// <returns>A newly created company</returns> 
        /// <response code="201">Returns the newly created item</response> 
        /// <response code="400">If the item is null</response> 
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> CreateCompany([FromBody]CompanyForCreationDto company)
        {
            
            /// <summary>
            /// add filter attribute remove code
            
            //if (company == null)
            //{
            //    _logger.LogError("CompanyForCreationDto object sent from client is null.");
            //    return BadRequest("CompanyForCreationDto object is null.");
            //}
            //if (!ModelState.IsValid)
            //{
            //    _logger.LogError("Invalid Model state for the CompanyForCreationDto object");
            //    return UnprocessableEntity(ModelState);
            //}

            var companyEntity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyEntity);
            await _repository.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id }, companyToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection == null)
            {
                _logger.LogError("Company collection sent from client is null.");
                return BadRequest("Company collection is null");
            }
            
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }
            
            await _repository.SaveAsync();
            
            var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("CompanyCollection", new { ids }, companyCollectionToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateCompanyExistsAttribute))]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            /// <summary>
            /// add filter attribute remove code
            //var company = await _repository.Company.GetCompanyAsync(id, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
            //    return NotFound();
            //} 


            //add action filter
            var company = HttpContext.Items["company"] as Company;

            _repository.Company.DeleteCompany(company);
            await _repository.SaveAsync();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCompanyExistsAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            /// <summary>
            /// add filter attribute remove code
            //if (company == null)
            //{
            //    _logger.LogError("CompanyForUpdateDto object sent from client is null.");
            //    return BadRequest("CompanyForUpdateDto object is null");
            //}
            //if (!ModelState.IsValid) 
            //{
            //    _logger.LogError("Invalid model state for the CompanyForUpdateDto object");
            //    return UnprocessableEntity(ModelState);
            //}


            /// <summary>
            /// add filter companyexistattribute remove code
            //var companyEntity = await _repository.Company.GetCompanyAsync(id, trackChanges: true);
            //if (companyEntity == null)
            //{
            //    _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
            //    return NotFound();
            //}

            //add action filter
            var companyEntity = HttpContext.Items["company"] as Company;

            _mapper.Map(company, companyEntity);
            await _repository.SaveAsync();
            
            return NoContent();
        }


        /// <summary>
        /// Synchronous Method
        /// </summary>
        /////
        //[HttpGet]
        //public IActionResult GetCompanies() 
        //{
        //    //try
        //    //{
        //        var companies = _repository.Company.GetAllCompanies(trackChanges: false);

        //        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        //    //throw new Exception("Exception");

        //    //var companiesDto = companies.Select(c => new CompanyDto
        //    //{
        //    //    Id = c.Id,
        //    //    Name = c.Name,
        //    //    FullAddress = string.Join(' ', c.Address, c.Country)
        //    //}).ToList();

        //    return Ok(companiesDto);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    _logger.LogError($"Something went wrong in the {nameof(GetCompanies)} action {ex}");

        //    //    return StatusCode(500, "Internal server error");
        //    //} 
        //}

        ////[HttpGet("{id}")]
        //[HttpGet("{id}", Name = "CompanyById")]
        //public IActionResult GetCompany(Guid id) 
        //{
        //    var company = _repository.Company.GetCompany(id, trackChanges: false);
        //    if (company == null) 
        //    {
        //        _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    } 
        //    else
        //    {
        //        var companyDto = _mapper.Map<CompanyDto>(company);
        //        return Ok(companyDto);
        //    }
        //}

        //[HttpPost]
        //public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        //{
        //    if (company == null)
        //    {
        //        _logger.LogError("Company ForCreationDto object send from client is null");
        //        return BadRequest("CompanyForCreationDto is null");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("Invalid model state for the CompanyForCreationDto object");
        //        return UnprocessableEntity(ModelState);
        //    }


        //    var companyEntity = _mapper.Map<Company>(company);

        //    _repository.Company.CreateCompany(companyEntity);
        //    _repository.Save();

        //    var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        //    return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id },
        //        companyToReturn);
        //}

        //[HttpGet("collection/({ids})", Name = "CompanyCollection")]
        ////public IActionResult GetCompanyCollection(IEnumerable<Guid> ids)
        //public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        //{
        //    if (ids == null)
        //    {
        //        _logger.LogError("Parameter ids in null");
        //        return BadRequest("Parameter ids is null");
        //    }

        //    var companyEntities = _repository.Company.GetByIds(ids, trackChanges: false);
        //    if (ids.Count() != companyEntities.Count())
        //    {
        //        _logger.LogError("Some ids are not valid in a collection");
        //        return NotFound();
        //    }

        //    var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        //    return Ok(companiesToReturn);
        //}

        //[HttpPost("collection")]
        //public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        //{
        //    if (companyCollection == null)
        //    {
        //        _logger.LogError("Company collection sent from client is null.");
        //        return BadRequest("Company collection is null.");
        //    }

        //    var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        //    foreach (var company in companyEntities)
        //    {
        //        _repository.Company.CreateCompany(company);
        //    }

        //    _repository.Save();

        //    var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        //    var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        //    return CreatedAtRoute("CompanyCollection", new { ids }, companyCollectionToReturn);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteCompany(Guid id)
        //{
        //    var company = _repository.Company.GetCompany(id, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    _repository.Company.DeleteCompany(company);
        //    _repository.Save();

        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        //{
        //    if (company == null)
        //    {
        //        _logger.LogError("CompanyForUpdateDto object sent from client is null.");
        //        return BadRequest("CompanyForUpdateDto object is null");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("Invalid model state for the CompanyForUpdateDto object");
        //        return UnprocessableEntity(ModelState);
        //    }

        //    var companyEntity = _repository.Company.GetCompany(id, trackChanges: true);
        //    if (companyEntity == null) 
        //    {
        //        _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    _mapper.Map(company, companyEntity);
        //    _repository.Save();

        //    return NoContent();
        //}
    }
}
