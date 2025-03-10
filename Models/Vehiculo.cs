using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Matricula { get; set; }
        public string? NumeroDeBastidor { get; set; }
        public string? Color { get; set; }
    }
}

//Buscar como añadir etiquetas a cada uno de los valores para mostrar o no mostrarlo en mi lista.