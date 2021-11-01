using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARAAPI.Controllers
{
    [Route("api/scan/{scanId}/faces")]
    [ApiController]
    public class FacesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FacesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFaceOfScan(int scanId) 
        { 
            var scanData = _repository.ScanData.GetScanDataById(scanId, trackChanges: false); 
            if (scanData == null) 
            { 
                _logger.LogInfo($"Company with id: {scanId} doesn't exist in the database."); 
                return NotFound(); 
            } 
            var facecFromDb = _repository.FaceData.GetFaces(scanId, trackChanges: false);
            var faceDto = _mapper.Map<IEnumerable<FaceDto>>(facecFromDb); 
            
            return Ok(faceDto); 
        }

        [HttpGet("{id}")] 
        public IActionResult GetFaceGetFaceById(int scanId, int id)
        { 
            var scandata = _repository.ScanData.GetScanDataById(scanId, trackChanges: false); 
            if (scandata == null) 
            { 
                _logger.LogInfo($"scandata with id: {scanId} doesn't exist in the database.");
                return NotFound(); 
            } 
            var facecFromDb = _repository.FaceData.GetFaceById(scanId, id, trackChanges: false); 
            if (facecFromDb == null) 
            { 
                _logger.LogInfo($"scandata with id: {id} doesn't exist in the database."); 
                return NotFound(); 
            } 
            var face = _mapper.Map<EmployeeDto>(facecFromDb); 
            return Ok(face); 
        }
    }
}
