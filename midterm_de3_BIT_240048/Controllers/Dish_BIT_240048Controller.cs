
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm_de3_BIT_240048.Models;
using midterm_de3_BIT_240048.Data;

public class Dish_BIT_240048Controller : Controller
{
    private readonly ApplicationDbContext _context;

    public Dish_BIT_240048Controller(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DISH_BIT_240048S
    public async Task<IActionResult> Index(
        string searchString,
        int? categoryId,
        bool? isAvailable,
        decimal? minPrice,
        decimal? maxPrice,
        string sortOrder)
        {
            var dishes = _context.Dishes_BIT_240048
                .Include(d => d.DishCategory)
                .AsQueryable();

            // tìm kiếm tên món ăn
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d =>
                    d.Name.Contains(searchString));
            }

            // lọc loại món ăn
            if (categoryId.HasValue)
            {
                dishes = dishes.Where(d =>
                    d.DishCategoryId == categoryId);
            }

            // lọc trạng thái bán
            if (isAvailable.HasValue)
            {
                dishes = dishes.Where(d =>
                    d.IsAvailable == isAvailable);
            }

            // khoảng giá
            if (minPrice.HasValue)
            {
                dishes = dishes.Where(d =>
                    d.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                dishes = dishes.Where(d =>
                    d.Price <= maxPrice);
            }

            // sắp xếp
            dishes = sortOrder switch
            {
                "price_desc" => dishes.OrderByDescending(d => d.Price),

                "price_asc" => dishes.OrderBy(d => d.Price),

                "time_asc" => dishes.OrderBy(d => d.PreparationTime),

                _ => dishes.OrderBy(d => d.Name)
            };

            ViewBag.Categories =
                await _context.DishCategories_BIT_240048.ToListAsync();

            ViewBag.SearchString = searchString;
            ViewBag.CategoryId = categoryId;
            ViewBag.IsAvailable = isAvailable;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SortOrder = sortOrder;

            return View(await dishes.ToListAsync());
        }

    // GET: DISH_BIT_240048S/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish_bit_240048 = await _context.Dishes_BIT_240048
            .Include(d => d.DishCategory)
            .Include(d => d.Images)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (dish_bit_240048 == null)
        {
            return NotFound();
        }

        return View(dish_bit_240048);
    }

    // GET: DISH_BIT_240048S/Create
    public IActionResult Create()
    {
        ViewBag.Categories =
            _context.DishCategories_BIT_240048.ToList();

        return View();
    }

    // POST: DISH_BIT_240048S/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Price,PreparationTime,IsAvailable,Description,DishCategoryId,DishCategory,Images")] Dish_BIT_240048 dish_bit_240048)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dish_bit_240048);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories =
            _context.DishCategories_BIT_240048.ToList();
        return View(dish_bit_240048);
    }

    // GET: DISH_BIT_240048S/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish_bit_240048 = await _context.Dishes_BIT_240048.FindAsync(id);
        if (dish_bit_240048 == null)
        {
            return NotFound();
        }
        ViewBag.Categories =
            _context.DishCategories_BIT_240048.ToList();
        return View(dish_bit_240048);
    }

    // POST: DISH_BIT_240048S/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Price,PreparationTime,IsAvailable,Description,DishCategoryId,DishCategory,Images")] Dish_BIT_240048 dish_bit_240048)
    {
        if (id != dish_bit_240048.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dish_bit_240048);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dish_BIT_240048Exists(dish_bit_240048.Id))
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
        ViewBag.Categories =
            _context.DishCategories_BIT_240048.ToList();
        return View(dish_bit_240048);
    }

    // GET: DISH_BIT_240048S/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish_bit_240048 = await _context.Dishes_BIT_240048
            .FirstOrDefaultAsync(m => m.Id == id);
        if (dish_bit_240048 == null)
        {
            return NotFound();
        }

        return View(dish_bit_240048);
    }

    // POST: DISH_BIT_240048S/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var dish_bit_240048 = await _context.Dishes_BIT_240048.FindAsync(id);
        if (dish_bit_240048 != null)
        {
            _context.Dishes_BIT_240048.Remove(dish_bit_240048);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool Dish_BIT_240048Exists(int? id)
    {
        return _context.Dishes_BIT_240048.Any(e => e.Id == id);
    }
}
