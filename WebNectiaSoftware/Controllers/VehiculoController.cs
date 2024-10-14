using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNectiaSoftware.Models;

[Authorize]
public class VehiculoController : Controller
{
    private readonly ApplicationDbContext _context;

    public VehiculoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Acción para mostrar el listado de vehículos
    [Authorize]
    public IActionResult Index()
    {
        var vehiculos = _context.Vehiculos.ToList();
        return View(vehiculos); // Asegúrate de que esté llamando correctamente a "View"
    }

    // Acción GET para mostrar el formulario de creación
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Acción POST para manejar la creación de un nuevo vehículo
    [HttpPost]
    public IActionResult Create(Vehiculo vehiculo)
    {
        if (ModelState.IsValid)
        {
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(vehiculo);
    }

    [HttpPost]
    public IActionResult Update(Vehiculo vehiculo)
    {
        _context.Vehiculos.Update(vehiculo);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var vehiculo = _context.Vehiculos.Find(id);
        if (vehiculo == null)
        {
            return NotFound();
        }

        _context.Vehiculos.Remove(vehiculo);
        _context.SaveChanges();

        return Ok();  // Devolver una respuesta exitosa
    }

    // Acción GET para cargar la vista de edición con los datos del vehículo
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var vehiculo = _context.Vehiculos.Find(id);
        if (vehiculo == null)
        {
            return NotFound(); // Retorna 404 si el vehículo no existe
        }
        return View(vehiculo); // Retorna la vista Edit con el vehículo encontrado
    }

    // Acción POST para manejar la actualización de los datos del vehículo
    [HttpPost]
    public IActionResult Edit(Vehiculo vehiculo)
    {
        if (ModelState.IsValid)
        {
            _context.Vehiculos.Update(vehiculo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(vehiculo);
    }
}
