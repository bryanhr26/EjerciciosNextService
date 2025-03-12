using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorApp1.Shared
{
    public partial class BaseFormulario<T> : ComponentBase
    {
        [Parameter] public T? RegistroOrigenTabla { get; set; }
        [Parameter] public Accion ModoAccion { get; set; }
        [Parameter] public EventCallback OnGuardarCambios { get; set; }
        [Parameter] public EventCallback OnEliminar { get; set; }
        [Parameter] public EventCallback OnCancelarEliminar { get; set; }

        public T? RegistroCompleto { get; set; }

        public PropertyInfo[]? Atributos = null;
        public PropiedadesFormularioAttribute[]? AtributosFormulario = null;

        protected override async Task OnInitializedAsync()
        {
            RegistroCompleto = RegistroOrigenTabla;
            Atributos = typeof(T).GetProperties();
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
            }
        }
    }
}
