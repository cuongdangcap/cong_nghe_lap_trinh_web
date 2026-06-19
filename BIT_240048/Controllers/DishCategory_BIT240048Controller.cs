
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BIT_240048.Models;
using BIT_240048.Data;

public class DishCategory_BIT240048Controller : Controller
{
    private readonly ApplicationDbContext _context;

    public DishCategory_BIT240048Controller(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DISHCATEGORY_BIT240048S
    public async Task<IActionResult> Index()    
    {
        return View(await _context.DishCategories_BIT240048.ToListAsync());
    }

    // GET: DISHCATEGORY_BIT240048S/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dishcategory_bit240048 = await _context.DishCategories_BIT240048
            .FirstOrDefaultAsync(m => m.Id == id);
        if (dishcategory_bit240048 == null)
        {
            return NotFound();
        }

        return View(dishcategory_bit240048);
    }

    // GET: DISHCATEGORY_BIT240048S/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DISHCATEGORY_BIT240048S/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] DishCategory_BIT240048 dishcategory_bit240048)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dishcategory_bit240048);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(dishcategory_bit240048);
    }

    // GET: DISHCATEGORY_BIT240048S/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dishcategory_bit240048 = await _context.DishCategories_BIT240048.FindAsync(id);
        if (dishcategory_bit240048 == null)
        {
            return NotFound();
        }
        return View(dishcategory_bit240048);
    }

    // POST: DISHCATEGORY_BIT240048S/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Description")] DishCategory_BIT240048 dishcategory_bit240048)
    {
        if (id != dishcategory_bit240048.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dishcategory_bit240048);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishCategory_BIT240048Exists(dishcategory_bit240048.Id))
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
        return View(dishcategory_bit240048);
    }

    // GET: DISHCATEGORY_BIT240048S/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dishcategory_bit240048 = await _context.DishCategories_BIT240048
            .FirstOrDefaultAsync(m => m.Id == id);
        if (dishcategory_bit240048 == null)
        {
            return NotFound();
        }

        return View(dishcategory_bit240048);
    }

    // POST: DISHCATEGORY_BIT240048S/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var dishcategory_bit240048 = await _context.DishCategories_BIT240048.FindAsync(id);
        if (dishcategory_bit240048 != null)
        {
            _context.DishCategories_BIT240048.Remove(dishcategory_bit240048);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DishCategory_BIT240048Exists(int? id)
    {
        return _context.DishCategories_BIT240048.Any(e => e.Id == id);
    }
}
