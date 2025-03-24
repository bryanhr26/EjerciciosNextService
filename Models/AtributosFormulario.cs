namespace BlazorApp1.Models
{
    public class AtributosFormulario
    {
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class PropiedadesFormularioAttribute : Attribute
        {
            public bool Visible { get; set; }
            public bool Habilitado { get; set; }
            public int Orden { get; set; }
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

        [AttributeUsage(AttributeTargets.Property)]
        public class OrdenFormularioAttribute : Attribute
        {
            public int Orden { get; set; }

            public OrdenFormularioAttribute(int orden)
            {
                Orden = orden;
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
    }
}
