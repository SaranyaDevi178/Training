using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.DatabaseEntity;

namespace DatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDoctorsController : ControllerBase
    {
        private readonly empdetailsContext _context;

        public TblDoctorsController(empdetailsContext context)
        {
            _context = context;
        }

        // GET: api/TblDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDoctor>>> GetTblDoctors()
        {
          if (_context.TblDoctors == null)
          {
              return NotFound();
          }
            return await _context.TblDoctors.ToListAsync();
        }

        // GET: api/TblDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDoctor>> GetTblDoctor(int id)
        {
          if (_context.TblDoctors == null)
          {
              return NotFound();
          }
            var tblDoctor = await _context.TblDoctors.FindAsync(id);

            if (tblDoctor == null)
            {
                return NotFound();
            }

            return tblDoctor;
        }

        // PUT: api/TblDoctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDoctor(int id, TblDoctor tblDoctor)
        {
            if (id != tblDoctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblDoctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDoctor>> PostTblDoctor(TblDoctor tblDoctor)
        {
          if (_context.TblDoctors == null)
          {
              return Problem("Entity set 'empdetailsContext.TblDoctors'  is null.");
          }
            _context.TblDoctors.Add(tblDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDoctor", new { id = tblDoctor.Id }, tblDoctor);
        }

        // DELETE: api/TblDoctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDoctor(int id)
        {
            if (_context.TblDoctors == null)
            {
                return NotFound();
            }
            var tblDoctor = await _context.TblDoctors.FindAsync(id);
            if (tblDoctor == null)
            {
                return NotFound();
            }

            _context.TblDoctors.Remove(tblDoctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDoctorExists(int id)
        {
            return (_context.TblDoctors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
