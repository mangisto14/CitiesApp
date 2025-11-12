using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;

public class CitiesController : Controller
{
    private readonly ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index(string search, string sortOrder, int page = 1)
    {
        var cities = db.Cities.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            cities = cities.Where(c => c.Name.Contains(search));
        }

        cities = sortOrder == "name_desc" ? cities.OrderByDescending(c => c.Name) : cities.OrderBy(c => c.Name);

        int pageSize = 10;
        var paged = cities.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return View(paged);
    }

    public ActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(City city)
    {
        if (ModelState.IsValid)
        {
            db.Cities.Add(city);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(city);
    }

    // Edit/Delete omitted for brevity
}
