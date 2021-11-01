using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanDatasController : ControllerBase
    {
        private readonly IScanRepository _context;

        //private readonly AppDbContext _context;

        //public ScanDatasController(AppDbContext context)
        //{
        //    _context = context;
        //}

        public ScanDatasController(IScanRepository context)
        {
            _context = context;
        }


        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<ScanData>>> Search(string name, string devno)
        {
            try
            {
                var result = await _context.Search(name, devno);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/ScanDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScanData>>> GetScanDatas()
        {
            //return await _context.ScanDatas.ToListAsync();
            try
            {
                return Ok(await _context.GetAllSc());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/ScanDatas/5
        [HttpGet("/{id}")]
        public async Task<ActionResult<ScanData>> GetScanData(int id)
        {

            try
            {
                var result = await _context.GetScById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

            ////var scanData = await _context.ScanDatas.SingleAsync(d => d.ScanId == id);

            //var scanData = await _context.ScanDatas
            //                        .Include(dinfo => dinfo.Faces)

            //                        .Where(d => d.ScanId == id)
            //                        .FirstOrDefaultAsync();

            ////_context.Entry(scanData)
            ////    .Reference(face => face.Faces)
            ////    .Query()
            ////    .Include(faces => faces.ToList)
            ////    .Load();

            //if (scanData == null)
            //{
            //    return NotFound();
            //}

            //return scanData;
        }

        //// PUT: api/ScanDatas/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutScanData(int id, ScanData scanData)
        //{
        //    if (id != scanData.ScanId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(scanData).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ScanDataExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ScanDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScanData>> PostScanData(ScanData scanData)
        {
            try
            {
                if (scanData == null)
                {
                    return BadRequest();
                }

                var emp = await _context.GetScById(scanData.ScanId);

                if (emp != null)
                {
                    ModelState.AddModelError("email", "Visitor email already in use");
                    return BadRequest(ModelState);
                }

                var addscan = await _context.AddScData(scanData);

                return CreatedAtAction(nameof(PostScanData),
                    new { id = addscan.ScanId}, addscan);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new visitor record");
            }
            //if (scanData == null)
            //{
            //    return BadRequest();
            //}


            //_context.ScanDatas.Add(scanData);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetScanData", new { id = scanData.ScanId }, scanData);
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
            //var scanData = await _context.ScanDatas.FindAsync(id);
            //if (scanData == null)
            //{
            //    return NotFound();
            //}

            //_context.ScanDatas.Remove(scanData);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        //private bool ScanDataExists(int id)
        //{
        //    return _context.ScanDatas.Any(e => e.ScanId == id);
        //}
    }
}
