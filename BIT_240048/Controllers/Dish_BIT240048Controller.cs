using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIT_240048.Models;
using BIT_240048.Data;

public class Dish_BIT240048Controller : Controller
{
    private readonly ApplicationDbContext _context;

    public Dish_BIT240048Controller(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Dish_BIT240048
    public async Task<IActionResult> Index()
    {
        var dishes = await _context.Dishes_BIT240048
            .Include(d => d.DishCategory)
            .ToListAsync();

        return View(dishes);
    }

    // GET: Dish_BIT240048/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish = await _context.Dishes_BIT240048
            .Include(d => d.DishCategory)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (dish == null)
        {
            return NotFound();
        }

        return View(dish);
    }

    // GET: Dish_BIT240048/Create
    public IActionResult Create()
    {
        ViewData["DishCategoryId"] =
            new SelectList(
                _context.DishCategories_BIT240048,
                "Id",
                "Name");

        return View();
    }

    // POST: Dish_BIT240048/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Name,Price,PreparationTime,IsAvailable,Description,DishCategoryId")]
        Dish_BIT240048 dish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["DishCategoryId"] =
            new SelectList(
                _context.DishCategories_BIT240048,
                "Id",
                "Name",
                dish.DishCategoryId);

        return View(dish);
    }

    // GET: Dish_BIT240048/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish = await _context.Dishes_BIT240048.FindAsync(id);

        if (dish == null)
        {
            return NotFound();
        }

        ViewData["DishCategoryId"] =
            new SelectList(
                _context.DishCategories_BIT240048,
                "Id",
                "Name",
                dish.DishCategoryId);

        return View(dish);
    }

    // POST: Dish_BIT240048/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Name,Price,PreparationTime,IsAvailable,Description,DishCategoryId")]
        Dish_BIT240048 dish)
    {
        if (id != dish.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dish);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(dish.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["DishCategoryId"] =
            new SelectList(
                _context.DishCategories_BIT240048,
                "Id",
                "Name",
                dish.DishCategoryId);

        return View(dish);
    }

    // GET: Dish_BIT240048/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish = await _context.Dishes_BIT240048
            .Include(d => d.DishCategory)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (dish == null)
        {
            return NotFound();
        }

        return View(dish);
    }

    // POST: Dish_BIT240048/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var dish = await _context.Dishes_BIT240048.FindAsync(id);

        if (dish != null)
        {
            _context.Dishes_BIT240048.Remove(dish);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool DishExists(int id)
    {
        return _context.Dishes_BIT240048.Any(e => e.Id == id);
    }
}