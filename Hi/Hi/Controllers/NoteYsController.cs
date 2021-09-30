using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hi.Contexts;
using Hi.Models;

namespace Hi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteYsController : ControllerBase
    {
        private readonly HiContext _context;

        public NoteYsController(HiContext context)
        {
            _context = context;
        }

        // GET: api/NoteYs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteY>>> GetNoteY()
        {
            return await _context.NoteY.ToListAsync();
        }

        // GET: api/NoteYs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteY>> GetNoteY(int id)
        {
            var noteY = await _context.NoteY.FindAsync(id);

            if (noteY == null)
            {
                return NotFound();
            }

            return noteY;
        }

        // PUT: api/NoteYs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteY(int id, NoteY noteY)
        {
            if (id != noteY.Id)
            {
                return BadRequest();
            }

            _context.Entry(noteY).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteYExists(id))
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

        // POST: api/NoteYs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NoteY>> PostNoteY(NoteY noteY)
        {
            _context.NoteY.Add(noteY);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoteY", new { id = noteY.Id }, noteY);
        }

        // DELETE: api/NoteYs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteY>> DeleteNoteY(int id)
        {
            var noteY = await _context.NoteY.FindAsync(id);
            if (noteY == null)
            {
                return NotFound();
            }

            _context.NoteY.Remove(noteY);
            await _context.SaveChangesAsync();

            return noteY;
        }

        private bool NoteYExists(int id)
        {
            return _context.NoteY.Any(e => e.Id == id);
        }
    }
}
