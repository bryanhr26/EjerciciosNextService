using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp1.Models;


public class PaisesService
{
    private readonly HttpClient _httpClient;

    public PaisesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Paises>> GetPaisesAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Paises>>("Paises.json");
            return response ?? new List<Paises>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener los datos: {ex.Message}");
            return new List<Paises>();
        }
    }
}
