using EvidenciaStudentov.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PouzivatelsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PouzivatelsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Pouzivatels
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Pouzivatelia.Include(p => p.Rola);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Pouzivatels/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pouzivatel = await _context.Pouzivatelia
            .Include(p => p.Rola)
            .FirstOrDefaultAsync(m => m.PouzivatelId == id);
        if (pouzivatel == null)
        {
            return NotFound();
        }

        return View(pouzivatel);
    }

    // GET: Pouzivatels/Create
    public IActionResult Create()
    {
        ViewData["RolaId"] = new SelectList(_context.Rola, "RolaId", "Nazov");
        return View();
    }

    // POST: Pouzivatels/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PouzivatelId,Meno,Priezvisko,DatumNarodenia,Email,HesloHash,RolaId")] Pouzivatel pouzivatel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pouzivatel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["RolaId"] = new SelectList(_context.Rola, "RolaId", "Nazov", pouzivatel.RolaId);
        return View(pouzivatel);
    }

    // GET: Pouzivatels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pouzivatel = await _context.Pouzivatelia.FindAsync(id);
        if (pouzivatel == null)
        {
            return NotFound();
        }
        ViewData["RolaId"] = new SelectList(_context.Rola, "RolaId", "Nazov", pouzivatel.RolaId);
        return View(pouzivatel);
    }

    // POST: Pouzivatels/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PouzivatelId,Meno,Priezvisko,DatumNarodenia,Email,HesloHash,RolaId")] Pouzivatel pouzivatel)
    {
        if (id != pouzivatel.PouzivatelId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pouzivatel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PouzivatelExists(pouzivatel.PouzivatelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["RolaId"] = new SelectList(_context.Rola, "RolaId", "Nazov", pouzivatel.RolaId);
        return View(pouzivatel);
    }

    // GET: Pouzivatels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pouzivatel = await _context.Pouzivatelia
            .Include(p => p.Rola)
            .FirstOrDefaultAsync(m => m.PouzivatelId == id);
        if (pouzivatel == null)
        {
            return NotFound();
        }

        return View(pouzivatel);
    }

    // POST: Pouzivatels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pouzivatel = await _context.Pouzivatelia.FindAsync(id);
        if (pouzivatel != null)
        {
            _context.Pouzivatelia.Remove(pouzivatel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PouzivatelExists(int id)
    {
        return _context.Pouzivatelia.Any(e => e.PouzivatelId == id);
    }
}