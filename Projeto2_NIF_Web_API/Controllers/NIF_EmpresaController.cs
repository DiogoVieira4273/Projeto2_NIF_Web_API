using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto2_NIF_Web_API.Models;

[Route("[controller]")]
[ApiController]
public class NIF_EmpresaController : ControllerBase
{
    private readonly NIFDbContext _context;
    public NIF_EmpresaController(NIFDbContext context)
    {
        _context = context;
    }

    // GET: /NIF_Empresa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NIF_Empresa>>> GetNIF_Empresa()
    {
        return await _context.NIF_Empresa.ToListAsync();
    }

    // GET: /NIF_Empresa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<NIF_Empresa>> GetNIF_Empresa(int id)
    {
        var nif_empresa = await _context.NIF_Empresa.FindAsync(id);

        if (nif_empresa == null)
        {
            return NotFound();
        }

        return nif_empresa;
    }

    // PUT: /NIF_Empresa/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNIF_Empresa(int? id, NIF_Empresa nif_empresa)
    {
        if (id != nif_empresa.ID)
        {
            return BadRequest();
        }

        _context.Entry(nif_empresa).State = EntityState.Modified;

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

    // POST: /NIF_Empresa
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<NIF_Empresa>> PostNIF_Empresa(NIF_Empresa nif_empresa)
    {
        _context.NIF_Empresa.Add(nif_empresa);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetNIF_Empresa", new { id = nif_empresa.ID }, nif_empresa);
    }

    // DELETE: /NIF_Empresa/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNIF_Empresa(int? id)
    {
        var nif_empresa = await _context.NIF_Empresa.FindAsync(id);
        if (nif_empresa == null)
        {
            return NotFound();
        }

        _context.NIF_Empresa.Remove(nif_empresa);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NIF_EmpresaExists(int? id)
    {
        return _context.NIF_Empresa.Any(e => e.ID == id);
    }
}
