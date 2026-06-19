
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BIT_240048.Models;
using BIT_240048.Data;

public class DishImage_BIT240048Controller : Controller
{
    private readonly ApplicationDbContext _context;

    public DishImage_BIT240048Controller(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DISHIMAGE_BIT240048S
    public async Task<IActionResult> Index()    
    {
        return View(await _context.DishImages_BIT240048.ToListAsync());
    }

    // GET: DISHIMAGE_BIT240048S/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dishimage_bit240048 = await _context.DishImages_BIT240048
            .FirstOrDefaultAsync(m => m.Id == id);
        if (dishimage_bit240048 == null)
        {
            return NotFound();
        }

        return View(dishimage_bit240048);
    }

    // GET: DISHIMAGE_BIT240048S/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DISHIMAGE_BIT240048S/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ImageUrl,IsThumbnail,DishId,Dish")] DishImage_BIT240048 dishimage_bit240048)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dishimage_bit240048);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(dishimage_bit240048);
    }

    // GET: DISHIMAGE_BIT240048S/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dishimage_bit240048 = await _context.DishImages_BIT240048.FindAsync(id);
        if (dishimage_bit240048 == null)
        {
            return NotFound();
        }
        return View(dishimage_bit240048);
    }

    // POST: DISHIMAGE_BIT240048S/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,ImageUrl,IsThumbnail,DishId,Dish")] DishImage_BIT240048 dishimage_bit240048)
    {
        if (id != dishimage_bit240048.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dishimage_bit240048);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishImage_BIT240048Exists(dishimage_bit240048.Id))
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
        return View(dishimage_bit240048);
    }

    // GET: DISHIMAGE_BIT240048S/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dishimage_bit240048 = await _context.DishImages_BIT240048
            .FirstOrDefaultAsync(m => m.Id == id);
        if (dishimage_bit240048 == null)
        {
            return NotFound();
        }

        return View(dishimage_bit240048);
    }

    // POST: DISHIMAGE_BIT240048S/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var dishimage_bit240048 = await _context.DishImages_BIT240048.FindAsync(id);
        if (dishimage_bit240048 != null)
        {
            _context.DishImages_BIT240048.Remove(dishimage_bit240048);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DishImage_BIT240048Exists(int? id)
    {
        return _context.DishImages_BIT240048.Any(e => e.Id == id);
    }
}
