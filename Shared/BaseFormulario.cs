using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using static BlazorApp1.Models.Tabla;

namespace BlazorApp1.Shared
{
    public partial class BaseFormulario<T> : ComponentBase
    {
        [Parameter] public T? RegistroOrigenTabla { get; set; }
        [Parameter] public Accion ModoAccion { get; set; }
        [Parameter] public EventCallback OnGuardarCambios { get; set; }
        [Parameter] public EventCallback OnEliminar { get; set; }
        [Parameter] public EventCallback OnCancelarEliminar { get; set; }
        [Parameter] public EventCallback<bool> OnFormularioModificado { get; set; }

        public T? RegistroCompleto { get; set; }

        public PropertyInfo[]? Atributos = null;
        public PropiedadesFormularioAttribute[]? AtributosFormulario = null;

        protected override async Task OnInitializedAsync()
        {
            RegistroCompleto = ClonarValoresObjetoGenerico(RegistroOrigenTabla);
            Atributos = typeof(T).GetProperties();
        }

        public T ClonarValoresObjetoGenerico<T>(T original)
        {
            // Crear una nueva instancia del mismo tipo de T
            T copia = Activator.CreateInstance<T>();

            // Obtener todas las propiedades públicas de la clase T
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Recorrer todas las propiedades y copiar los valores
            foreach (var propiedad in propiedades)
            {
                // Asegurarse de que la propiedad sea pública y tenga un setter
                if (propiedad.CanWrite)
                {
                    // Obtener el valor de la propiedad del objeto original
                    var valorOriginal = propiedad.GetValue(original);

                    // Establecer el mismo valor en la propiedad del objeto copia
                    propiedad.SetValue(copia, valorOriginal);
                }
            }

            return copia;
        }

        public PropiedadesFormularioAttribute? ObtenerDatosFormularioAtributo(PropertyInfo atributo)
        {
            // Verificamos si la propiedad tiene el atributo PropiedadTablaColumna
            var atributosFormulario = atributo.GetCustomAttribute<PropiedadesFormularioAttribute>();
            if (atributosFormulario != null)
            {
                return atributosFormulario;
            }
            return null;
        }

        public string ObtenerTipoLabel(PropertyInfo propiedad)
        {
            string tipoLabel = "";

            if (propiedad.PropertyType == typeof(string))
            {
                tipoLabel = "text";
            }

            if (propiedad.PropertyType == typeof(int))
            {
                tipoLabel = "number";
            }

            return tipoLabel;
        }

        public void ActualizarValor(ChangeEventArgs e, string propiedad)
        {
            // Obtiene el nuevo valor desde el evento ChangeEventArgs
            var nuevoValor = e.Value.ToString();

            // Usamos reflexión para obtener la propiedad correspondiente en el objeto
            var propiedadInfo = typeof(T).GetProperty(propiedad);

            if (propiedadInfo != null && propiedadInfo.CanWrite)
            {
                // Asignamos el nuevo valor a la propiedad
                propiedadInfo.SetValue(RegistroCompleto, Convert.ChangeType(nuevoValor, propiedadInfo.PropertyType));
                OnFormularioModificado.InvokeAsync(true);
            }
        }
    }
}
