using System.Net.Http.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class ServicoClima
{
    private const string ChaveApi = "e74f4c6280d9832d1699ccba88c336b2";
    private const string UrlBase = "https://api.openweathermap.org/data/2.5/weather";
    private readonly HttpClient _clienteHttp;

    public ServicoClima(HttpClient clienteHttp)
    {
        _clienteHttp = clienteHttp;
    }

    public async Task<RespostaClima?> ObterClimaAsync(double latitude, double longitude, string unidades = "metric", string idioma = "pt")
    {
        var url = $"{UrlBase}?lat={latitude}&lon={longitude}&units={unidades}&lang={idioma}&appid={ChaveApi}";
        try
        {
            return await _clienteHttp.GetFromJsonAsync<RespostaClima>(url);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar dados: {ex.Message}");
            return null;
        }
    }
}
