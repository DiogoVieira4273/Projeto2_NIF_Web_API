using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto2_NIF_Web_API.Models;

namespace Projeto2_NIF_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NIF_EmpresaController : ControllerBase
    {
        private readonly NIFDbContext _context;

        public NIF_EmpresaController(NIFDbContext context)
        {
            _context = context;
        }

        // GET: api/NIF_Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NIF_Empresa>>> GetNIF_Empresa()
        {
            return await _context.NIF_Empresa.ToListAsync();
        }

        // GET: api/NIF_Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NIF_Empresa>> GetNIF_Empresa(int id)
        {
            var nIF_Empresa = await _context.NIF_Empresa.FindAsync(id);

            if (nIF_Empresa == null)
            {
                return NotFound();
            }

            return nIF_Empresa;
        }

        // PUT: api/NIF_Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNIF_Empresa(int id, NIF_Empresa nIF_Empresa)
        {
            if (id != nIF_Empresa.ID)
            {
                return BadRequest();
            }

            _context.Entry(nIF_Empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NIF_EmpresaExists(id))
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

        // POST: api/NIF_Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NIF_Empresa>> PostNIF_Empresa(NIF_Empresa nIF_Empresa)
        {
            _context.NIF_Empresa.Add(nIF_Empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNIF_Empresa", new { id = nIF_Empresa.ID }, nIF_Empresa);
        }

        // DELETE: api/NIF_Empresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNIF_Empresa(int id)
        {
            var nIF_Empresa = await _context.NIF_Empresa.FindAsync(id);
            if (nIF_Empresa == null)
            {
                return NotFound();
            }

            _context.NIF_Empresa.Remove(nIF_Empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NIF_EmpresaExists(int id)
        {
            return _context.NIF_Empresa.Any(e => e.ID == id);
        }
    }
}
