using System.Reflection;

namespace BlazorApp1.Models
{
    public class AtributosTabla
    {
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class PropiedadTablaColumnaAttribute : Attribute
        {
            public string Nombre { get; }
            public bool Visible { get; }
            public int Ancho { get; }
            public string AlineacionTexto { get; }
            public bool EsAccion { get; }

            public PropiedadTablaColumnaAttribute(string nombre, bool visible = true, int ancho = 100, string alineacionTexto = "", bool esAccion = false)
            {
                Nombre = nombre;
                Visible = visible;
                Ancho = ancho;
                AlineacionTexto = alineacionTexto;
                EsAccion = esAccion;
            }
        }

        public enum Accion
        {
            Ver,
            Editar,
            Eliminar
        }

        public class PropiedadesTablaColumna
        {
            public string Nombre { get; set; } = string.Empty;
            public bool Visible { get; set; } = true;
            public int Ancho { get; set; } = 100;
            public string AlineacionTexto { get; set; } = "left";
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
                            AlineacionTexto = atributo.AlineacionTexto,
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
}
