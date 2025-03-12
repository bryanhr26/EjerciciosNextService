namespace BlazorApp1.Models
{
    public enum Accion
    {
        Ver,
        Editar,
        Eliminar
    }

    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public string NumeroDeBastidor { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public static List<PropiedadesTablaColumna> ObtenerPropiedadesColumnas<T>()
        {
            // Puedes definir cómo deseas manejar las columnas de manera genérica
            var propiedades = new List<PropiedadesTablaColumna>
            {
                new PropiedadesTablaColumna { Nombre = "Marca del vehículo", Visible = true, Ancho = 500, PropiedadModelo = "Marca"},
                new PropiedadesTablaColumna { Nombre = "Modelo del vehículo", Visible = true, Ancho = 300, PropiedadModelo = "Modelo" },
                new PropiedadesTablaColumna { Nombre = "Matricula del vehículo", Visible = true, Ancho = 200, PropiedadModelo = "Matricula" },
                new PropiedadesTablaColumna { Nombre = "Acciones", Visible = true, Ancho = 200, EsAccion = true },
            };
            return propiedades;
        }
    }

    public class PropiedadesTablaColumna
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public int Ancho { get; set; } = 100;
        public bool EsAccion { get; set; } = false; // Para saber si es una columna de acción (ver, editar, eliminar)
        public string PropiedadModelo { get; set; } = string.Empty; // Nombre real de la propiedad en el modelo
    }
}


//Buscar como añadir etiquetas a cada uno de los valores para mostrar o no mostrarlo en mi lista.
// Configurar el atributo para modificar estilo (nombre, ancho)

//En la fila le añades una lista de Enums en la cual le puedes decir la accion: ver, editar, eliminar
//Desde fuera le dirás a la fila que accion puede hacer
//Segun la accion que pueda hacer, en la tabla mostrará en esa FILA (Columna acciones) lo que puede hacer
//Al darle click a ver, te abre una ficha lateral que es un Formulario con los datos de la fila que has seleccionado, lo hace la propia tabla.
//Quiero que el formulario tambien lo haga dinamicamente como con reflection la tabla