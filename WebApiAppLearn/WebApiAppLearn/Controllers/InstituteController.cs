using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAppLearn.DataContext;
using WebApiAppLearn.Models;

namespace WebApiAppLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly AppLearnContext _context;

        public InstituteController(AppLearnContext context)
        {
            _context = context;
        }

        // GET: api/Institute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institute>>> GetInstitutes()
        {
            return await _context.Institutes.ToListAsync();
        }

        // GET: api/Institute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institute>> GetInstitute(int id)
        {
            var institute = await _context.Institutes.FindAsync(id);

            if (institute == null)
            {
                return NotFound();
            }

            return institute;
        }

        // PUT: api/Institute/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitute(int id, Institute institute)
        {
            if (id != institute.id)
            {
                return BadRequest();
            }

            _context.Entry(institute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituteExists(id))
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

        // POST: api/Institute
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Institute>> PostInstitute(Institute institute)
        {
            _context.Institutes.Add(institute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitute", new { id = institute.id }, institute);
        }

        // DELETE: api/Institute/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Institute>> DeleteInstitute(int id)
        {
            var institute = await _context.Institutes.FindAsync(id);
            if (institute == null)
            {
                return NotFound();
            }

            _context.Institutes.Remove(institute);
            await _context.SaveChangesAsync();

            return institute;
        }

        private bool InstituteExists(int id)
        {
            return _context.Institutes.Any(e => e.id == id);
        }
    }
}
