using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static BlazorApp1.Models.AtributosFormulario;
using static BlazorApp1.Models.AtributosTabla;

namespace BlazorApp1.Models
{
    public class Paises
    {

        public int id { get; set; }
        [OrdenFormulario(1)]
        [PropiedadTablaColumna("Código", true, 200, "left")]
        [PropiedadesFormulario(visible: true, ancho: "200px", habilitado: true, Titulo = "Código del país:")]
        public string? codigo { get; set; }
        [OrdenFormulario(3)]
        [PropiedadTablaColumna("Nombre", true, 600)]
        [PropiedadesFormulario(visible: true, ancho: "600px", habilitado: true, Titulo = "Nombre del país:")]
        public string? nombre { get; set; }
        [OrdenFormulario(2)]
        [PropiedadTablaColumna("Cod. internacional", true, 600)]
        [PropiedadesFormulario(visible: true, ancho: "200px", habilitado: true, Titulo = "Código internacional:", SaltoLinea = true)]
        public string? codInternacional { get; set; }
        [OrdenFormulario(4)]
        [PropiedadTablaColumna("Miembro CEE", true, 250, "center")]
        [PropiedadesFormulario(visible: true, ancho: "15px", habilitado: true, margenes: "2px;", Titulo = "Miembro CEE", Subtexto = "País perteneciente a la Comunidad Ecónomica Europea (CEE).")]
        public bool miembroCEE { get; set; }
        [PropiedadTablaColumna("Defecto", true, 100, "center")]
        public bool defecto { get; set; }
        [PropiedadTablaColumna("Baja", true, 75, "center")]
        public bool baja { get; set; }
        [OrdenFormulario(5)]
        [PropiedadTablaColumna("Predefinido", false, 75, "center")]
        [PropiedadesFormulario(visible: true, ancho: "15px", habilitado: true, Titulo = "País predefinido", Subtexto = "Si en el sistema exista la opción de seleccionar mas de un país, éste será el país seleccionado por defecto.")]
        public bool esPredefinido { get; set; }
        [PropiedadTablaColumna("Acción", true, 200, "left", true)]
        public string Acciones { get; set; } = string.Empty; // Este campo podría ser utilizado para botones de acción, como "editar" o "eliminar"
    }
}
