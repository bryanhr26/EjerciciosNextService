namespace BlazorApp1.Models
{
    public class Tabla
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
            public PestanyaEnum Pestanya { get; set; }
            public string Titulo { get; set; }
            public string Subtexto { get; set; }
            public string Margenes { get; set; }

            public PropiedadesFormularioAttribute(bool visible = true, string ancho = "100%", bool habilitado = true, PestanyaEnum pestanya = PestanyaEnum.Uno, string titulo = "", string subtexto = "", string margenes = "")
            {
                Visible = visible;
                Habilitado = habilitado;
                Ancho = ancho;
                Pestanya = pestanya;
                Titulo = titulo;
                Subtexto = subtexto;
                Margenes = margenes;
            }
        }

        public class Tabulacion
        {
            public PestanyaEnum ID { get; set; }
            public string Nombre { get; set; }
        }

        public enum PestanyaEnum
        {
            Uno = 1,
            Dos = 2,
            Tres = 3
        }

        public enum Accion
        {
            Ver,
            Editar,
            Eliminar
        }
    }
}
