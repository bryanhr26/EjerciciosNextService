using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp1.Models;


public class FacturacionService
{
    private readonly HttpClient _httpClient;

    public FacturacionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Facturacion>> GetFacturacionAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Facturacion>>("facturacion.json");
            return response ?? new List<Facturacion>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener los datos: {ex.Message}");
            return new List<Facturacion>();
        }
    }
}
