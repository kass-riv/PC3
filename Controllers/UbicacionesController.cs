using Microsoft.AspNetCore.Mvc;
using pokemonapp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pokemonapp.Controllers
{
    public class UbicacionesController : Controller
    {
        private readonly PokemonContext _context;
        public UbicacionesController(PokemonContext context) {
            _context = context;
        }

        public IActionResult Regiones() {
            var regiones = _context.Regiones.Include(x => x.Pueblos).OrderBy(r => r.Nombre).ToList();
            return View(regiones);
        }

        public IActionResult Pueblos() {
            var pueblos = _context.Pueblos.Include(x => x.Region).OrderBy(r => r.Nombre).ToList();
            return View(pueblos);
        }

        public IActionResult Entrenador() {
            var entrenador = _context.Entrenadores.Include(x => x.Foto ).OrderBy(r => r.Nombre).ToList();
            return View(entrenador);
        }

        public IActionResult NuevoPueblo() {
            ViewBag.Regiones = _context.Regiones.ToList().Select(r => new SelectListItem(r.Nombre, r.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult NuevoPueblo(Pueblo r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevoPuebloConfirmacion");
            }
            return View(r);
        }

        public IActionResult NuevoPuebloConfirmacion() {
            return View();
        }

        public IActionResult NuevaRegion() {
            return View();
        }

         public IActionResult Nuevoentrenador() {
            return View();
        }

        [HttpPost]
        public IActionResult NuevaRegion(Region r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevaRegionConfirmacion");
            }
            return View(r);
        }
        [HttpPost]
        public IActionResult Nuevoentrenador(Entrenador e) {
            if (ModelState.IsValid) {
                _context.Add(e);
                _context.SaveChanges();
                return RedirectToAction("NuevoEntrenadorConfirmacion");
            }
            return View(e);
        }
public IActionResult NuevoEntrenadorConfirmacion() {
            return View();
        }
        public IActionResult NuevaRegionConfirmacion() {
            return View();
        }
[HttpPost]
        public IActionResult BorrarEntrenador(int id) {
            var entrenador = _context.Regiones.Find(id);
            _context.Remove(entrenador);
            _context.SaveChanges();

            return RedirectToAction("entrenador");
        }




        [HttpPost]
        public IActionResult BorrarRegion(int id) {
            var region = _context.Regiones.Find(id);
            _context.Remove(region);
            _context.SaveChanges();

            return RedirectToAction("Regiones");
        }

        public IActionResult EditarRegion(int id) {
            var region = _context.Regiones.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult EditarRegion(Region r) {
            if (ModelState.IsValid) {
                var region = _context.Regiones.Find(r.Id);
                region.Nombre = r.Nombre;
                _context.SaveChanges();
                return RedirectToAction("EditarRegionConfirmacion");
            }
            return View(r);
        }

public IActionResult Editarentrenador(int id) {
            var entrenador = _context.Entrenadores.Find(id);
            return View(entrenador);
        }
public IActionResult Editarentrenador(Entrenador E) {
            if (ModelState.IsValid) {
                var entrenador = _context.Regiones.Find(E.Id);
                entrenador.Nombre = E.Nombre;
                _context.SaveChanges();
                return RedirectToAction("EditarEntrenadorConfirmacion");
            }
            return View(E);
        }
 public IActionResult EditarEntrenadorConfirmacion() {
            return View();
        }
        public IActionResult EditarRegionConfirmacion() {
            return View();
        }
    }
}