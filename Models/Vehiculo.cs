using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace BlazorApp1.Models
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class PropiedadTablaColumnaAttribute : Attribute
    {
        public string Nombre { get; }
        public bool Visible { get; }
        public int Ancho { get; }
        public bool EsAccion { get; }

        public PropiedadTablaColumnaAttribute(string nombre, bool visible = true, int ancho = 100, bool esAccion = false)
        {
            Nombre = nombre;
            Visible = visible;
            Ancho = ancho;
            EsAccion = esAccion;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class PropiedadesFormularioAttribute : Attribute
    {
        public bool Visible { get; set; }
        public bool Habilitado { get; set; }
        public string? Ancho { get; set; }
        public int Posicion { get; set; }
        public string Titulo { get; set; }
        public string Subtexto { get; set; }

        public PropiedadesFormularioAttribute(bool visible = true, string ancho = "100%", bool habilitado = true, int posicion = 1, string titulo = "", string subtexto = "")
        {
            Visible = visible;
            Habilitado = habilitado;
            Ancho = ancho;
            Posicion = posicion;
            Titulo = titulo;
            Subtexto = subtexto;
        }
    }

    public enum Pestanya
    {
        Uno,
        Dos,
        Tres 
    }

    public enum Accion
    {
        Ver,
        Editar,
        Eliminar
    }

    public class Vehiculo
    {
        public int Id { get; set; }

        [PropiedadTablaColumna("Marca del vehículo", true, 500)]
        [PropiedadesFormulario(visible: true, ancho: "350px", habilitado:true, posicion: 1)]
        public string Marca { get; set; } = string.Empty;

        [PropiedadTablaColumna("Modelo del vehículo", true, 300)]
        [PropiedadesFormulario(visible: true, ancho: "250px", habilitado:false, posicion: 2)]
        public string Modelo { get; set; } = string.Empty;

        [PropiedadTablaColumna("Matricula del vehículo", true, 200)]
        [PropiedadesFormulario(visible: true, ancho: "250px", habilitado:false, posicion: 3)]
        public string Matricula { get; set; } = string.Empty;

        [PropiedadTablaColumna("Kilometros", true, 200)]
        [PropiedadesFormulario(visible: true, habilitado: true, posicion: 4)]
        public int Kilometraje { get; set; }

        public string NumeroDeBastidor { get; set; } = string.Empty;

        [PropiedadesFormulario(visible: false, ancho: "250px", habilitado:false, posicion: 5)]
        public string Color { get; set; } = string.Empty;

        [PropiedadTablaColumna("Acciones", true, 200, true)]
        public string Acciones { get; set; } = string.Empty; // Este campo podría ser utilizado para botones de acción, como "editar" o "eliminar"
    }

    public class PropiedadesTablaColumna
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public int Ancho { get; set; } = 100;
        public bool EsAccion { get; set; } = false; // Para saber si es una columna de acción (ver, editar, eliminar)
        public string PropiedadModelo { get; set; } = string.Empty; // Nombre real de la propiedad en el modelo
    }

    public static class Utilidades
    {
        public static List<PropiedadesTablaColumna> ObtenerPropiedadesColumnas<T>()
        {
            var propiedades = new List<PropiedadesTablaColumna>();

            // Obtenemos todas las propiedades de la clase T
            var tipo = typeof(T);
            var propiedadesClases = tipo.GetProperties();

            foreach (var propiedad in propiedadesClases)
            {

                // Verificamos si la propiedad tiene el atributo PropiedadTablaColumna
                var atributo = propiedad.GetCustomAttribute<PropiedadTablaColumnaAttribute>();
                if (atributo != null)
                {
                    // Si tiene el atributo, creamos un objeto PropiedadesTablaColumna
                    var columna = new PropiedadesTablaColumna
                    {
                        Nombre = atributo.Nombre,
                        Visible = atributo.Visible,
                        Ancho = atributo.Ancho,
                        EsAccion = atributo.EsAccion,
                        PropiedadModelo = propiedad.Name
                    };

                    propiedades.Add(columna);
                }
            }

            return propiedades;
        }
    }
}


//Buscar como añadir etiquetas a cada uno de los valores para mostrar o no mostrarlo en mi lista.
// Configurar el atributo para modificar estilo (nombre, ancho)

//En la fila le añades una lista de Enums en la cual le puedes decir la accion: ver, editar, eliminar
//Desde fuera le dirás a la fila que accion puede hacer
//Segun la accion que pueda hacer, en la tabla mostrará en esa FILA (Columna acciones) lo que puede hacer
//Al darle click a ver, te abre una ficha lateral que es un Formulario con los datos de la fila que has seleccionado, lo hace la propia tabla.
//Quiero que el formulario tambien lo haga dinamicamente como con reflection la tabla