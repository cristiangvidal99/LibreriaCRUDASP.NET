using Microsoft.AspNetCore.Mvc;
using proyecto.Data;
using proyecto.Models;


namespace proyecto.Controllers
{
    public class CRUDController : Controller
    {
        // de la carpeta data
        DataLibro librosDatos = new DataLibro();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            var lista = librosDatos.Listar();
            // va a estar disponible en la vista pero todavia no se usa
            return View(lista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost] // indicamos que con el guardarform va a la db
        public IActionResult GuardarForm(ModelLibro libro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = librosDatos.Crear(libro); // guarda los datos enviados desde la vista

            if (response)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // si falla recarga la vista de nuevo
                return View();
            }

        }

        public IActionResult Editar(int id)
        {
            var libro = librosDatos.Obtener(id);
            return View(libro);
        }
        [HttpPost]
        public IActionResult Editar(ModelLibro libro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = librosDatos.Editar(libro);
            if (response)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Eliminar(int id)
        {
            var libro = librosDatos.Obtener(id);
            return View(libro);
        }
        [HttpPost]
        public IActionResult Eliminar(ModelLibro libro)
        {
            var response = librosDatos.Eliminar(libro.id);
            if (response)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}

