using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static BlazorApp1.Models.AtributosFormulario;
using static BlazorApp1.Models.AtributosTabla;

namespace BlazorApp1.Models
{
    public class Facturacion
    {

        public int id { get; set; }
        [OrdenFormulario(1)]
        [PropiedadTablaColumna("Código", true, 150, "left")]
        [PropiedadesFormulario(visible: true, ancho: "200px", habilitado: true, Titulo = "Código")]
        public string? codigo { get; set; }
        [OrdenFormulario(2)]
        [PropiedadTablaColumna("Norma", true, 100)]
        [PropiedadesFormulario(visible: true, ancho: "750px", habilitado: true, Titulo = "Norma")]
        public string? norma { get; set; }
        [OrdenFormulario(3)]
        [PropiedadTablaColumna("Descripción", true, 820)]
        [PropiedadesFormulario(visible: true, ancho: "750px", habilitado: true, Titulo = "Descripción")]
        public string? descripcion { get; set; }
        [OrdenFormulario(4)]
        [PropiedadTablaColumna("Tasa impositiva", true, 150, "center")]
        [PropiedadesFormulario(visible: true, ancho: "15px", habilitado: true, margenes: "2px;", Titulo = "Tasa impositiva")]
        public bool tasaImpositiva { get; set; }
        [PropiedadTablaColumna("Baja", true, 75, "center")]
        public bool baja { get; set; }
        [PropiedadTablaColumna("Acción", true, 200, "left", true)]
        public string Acciones { get; set; } = string.Empty; // Este campo podría ser utilizado para botones de acción, como "editar" o "eliminar"
    }
}
