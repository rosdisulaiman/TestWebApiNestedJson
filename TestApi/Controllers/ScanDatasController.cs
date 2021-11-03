using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models;
using TestApi.Models.DataTransferObjects;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanDatasController : ControllerBase
    {
        private readonly IScanRepository _context;
        private readonly IMapper _mapper;

        //private readonly AppDbContext _context;

        //public ScanDatasController(AppDbContext context)
        //{
        //    _context = context;
        //}

        public ScanDatasController(IScanRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ScanDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScanData>>> GetScanDatas()
        {
            //return await _context.ScanDatas.ToListAsync();
            try
            {
                var result = await _context.GetAllSc();

                var scanDto = _mapper.Map<IEnumerable<ScanDataDTO>>(result);

                return Ok(scanDto);

                //return Ok(await _context.GetAllSc());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/ScanDatas/5
        [HttpGet("{id}", Name = "ScanById")]
        public async Task<ActionResult<ScanData>> GetScanData(int id)
        {

            try
            {
                var result = await _context.GetScById(id);

                if (result == null)
                {
                    return NotFound();
                }

                var ScanDataDto = _mapper.Map<ScanDataDTO>(result);
                return Ok(ScanDataDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        // POST: api/ScanDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScanDataForCreationDto>> PostScanData([FromBody]ScanData scanData)
        {
            try
            {

                if (scanData == null)
                {
                    return BadRequest();
                }

                var addscan = await _context.AddScData(scanData);

                var dataToReturn = _mapper.Map<ScanDataForCreationDto>(scanData);

                return CreatedAtRoute("ScanById", new { id = dataToReturn.ScanId }, dataToReturn);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new visitor record");
            }
        }

        // DELETE: api/ScanDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScanData>> DeleteScanData(int id)
        {
            try
            {
                var visitorToDelete = await _context.GetScById(id);

                if (visitorToDelete == null)
                {
                    return NotFound($"Data with ID ={id} not found");
                }

                return await _context.DeleteSc(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
