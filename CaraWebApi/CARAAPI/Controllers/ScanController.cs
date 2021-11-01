using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARAAPI.Controllers
{
    [Route("api/scandata")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ScanController : ControllerBase
    {
        private readonly IRepositoryManager _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ScanController(IRepositoryManager context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpOptions]
        public IActionResult GetScanOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS, SEARCH, POST");
            return Ok();
        }

        [HttpGet] 
        public async Task<IActionResult> GetScansData() 
        { 
                var scanData = await _context.ScanData.GetAllScanAsync(trackChanges: false);
                //var scanDTO1 = scanData.Select(d => new ScanDto 
                //{
                    
                //}).ToList();

                var scanDto = _mapper.Map<IEnumerable<ScanDto>>(scanData);
                return Ok(scanDto);
        }

        [HttpGet("{id}", Name = "ScanById")]
        public async Task<IActionResult> GetScanDataById(int scanId)
        {
            var scanData = await _context.ScanData.GetScanAsync(scanId, trackChanges: false);
           
            var scanDto = _mapper.Map<ScanNestedDto>(scanData);
            return Ok(scanData);

        }

        [HttpPost]
        public async Task<IActionResult> AddScanData([FromBody] ScanData scanData)
        {
            if (scanData == null)
            {
                _logger.LogError("ScanForCreationDto object sent from client is null.");
                return BadRequest("ScanForCreationDto object is null");
            }
            var scanDataEntity = _mapper.Map<ScanData>(scanData); 
            
            _context.ScanData.AddScanData(scanDataEntity);
            _context.SaveAsync(); 
            
            var scanToReturn = _mapper.Map<ScanDto>(scanDataEntity); 
            
            return CreatedAtRoute("ScanById", new { id = scanToReturn.Id }, scanToReturn);
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteScan(int id) 
        { 
            var company = await _context.ScanData.GetScanAsync(id, trackChanges: false); 
            if (company == null) 
            { 
                _logger.LogInfo($"ScanData with id: {id} doesn't exist in the database."); 
                return NotFound(); 

            } 
            
            _context.ScanData.DeleteScanData(company); 
            await _context.SaveAsync();
            
            return NoContent(); 
        }
    }
}
