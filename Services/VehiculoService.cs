using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp1.Models;


public class VehiculoService
{
    private readonly HttpClient _httpClient;

    public VehiculoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Vehiculo>> GetVehiculosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Vehiculo>>("Vehiculos.json");
        return response ?? new List<Vehiculo>();
    }
}
