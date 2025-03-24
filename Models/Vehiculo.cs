using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static BlazorApp1.Models.AtributosFormulario;
using static BlazorApp1.Models.AtributosTabla;
namespace BlazorApp1.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        [PropiedadTablaColumna("Marca del vehículo", true, 500)]
        [PropiedadesFormulario(visible: true, ancho: "350px", habilitado:true, pestanya: PestanyaEnum.Uno)]
        public string Marca { get; set; } = string.Empty;

        [PropiedadTablaColumna("Modelo del vehículo", true, 300)]
        [PropiedadesFormulario(visible: true, ancho: "500px", habilitado:false, pestanya: PestanyaEnum.Uno, margenes: "5px")]
        public string Modelo { get; set; } = string.Empty;

        [PropiedadTablaColumna("Matricula del vehículo", true, 200)]
        [PropiedadesFormulario(visible: true, ancho: "100%", habilitado:false, pestanya: PestanyaEnum.Uno, margenes: "20px 0 0 0")]
        public string Matricula { get; set; } = string.Empty;

        [PropiedadTablaColumna("Kilometros", true, 200)]
        [PropiedadesFormulario(visible: true, habilitado: true, pestanya: PestanyaEnum.Dos)]
        public int Kilometraje { get; set; }

        [PropiedadesFormulario(visible: true, ancho: "250px", habilitado: false, pestanya: PestanyaEnum.Tres)]
        public string NumeroDeBastidor { get; set; } = string.Empty;

        [PropiedadesFormulario(visible: true, ancho: "250px", habilitado:false, pestanya: PestanyaEnum.Dos)]
        public string Color { get; set; } = string.Empty;

        [PropiedadTablaColumna("Acciones", true, 200, "left", true)]
        public string Acciones { get; set; } = string.Empty; // Este campo podría ser utilizado para botones de acción, como "editar" o "eliminar"
    }

}


//Buscar como añadir etiquetas a cada uno de los valores para mostrar o no mostrarlo en mi lista.
// Configurar el atributo para modificar estilo (nombre, ancho)

//En la fila le añades una lista de Enums en la cual le puedes decir la accion: ver, editar, eliminar
//Desde fuera le dirás a la fila que accion puede hacer
//Segun la accion que pueda hacer, en la tabla mostrará en esa FILA (Columna acciones) lo que puede hacer
//Al darle click a ver, te abre una ficha lateral que es un Formulario con los datos de la fila que has seleccionado, lo hace la propia tabla.
//Quiero que el formulario tambien lo haga dinamicamente como con reflection la tabla