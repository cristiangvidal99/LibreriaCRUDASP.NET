using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public class ModelLibro
    {
        // columnas de la tabla empieza en Mayuscula buena practica
        public int id { get; set; }

        // Campo Nombre
        [Required(ErrorMessage = "El campo del Nombre es obligatorio.")]
        public string? nombre { get; set; }

        // Campo Autor
        [Required(ErrorMessage = "El campo del Autor es obligatorio.")]
        public string? autor { get; set; }

        // Campo Genero
        [Required(ErrorMessage = "El campo del Genero es obligatorio.")]
        public string? genero { get; set; }

        // Campo NumPaginas
        [Required(ErrorMessage = "El campo del Numero de Páginas es obligatorio.")]
        public int numPaginas { get; set; }

        // Campo Precio 
        [Required(ErrorMessage = "El campo del Precio es obligatorio.")]
        public int precio { get; set; }
    }
}
