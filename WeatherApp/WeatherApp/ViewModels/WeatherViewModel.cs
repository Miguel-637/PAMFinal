using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.ViewModels;

public partial class ClimaViewModel : ObservableObject
{
    private readonly ServicoClima _servicoClima;

    [ObservableProperty]
    private string temperatura = "Carregando...";

    [ObservableProperty]
    private string descricao = "Carregando...";

    [ObservableProperty]
    private bool estaOcupado;

    public ClimaViewModel()
    {
        _servicoClima = new ServicoClima(new HttpClient());
    }

    [RelayCommand]
    public async Task ObterClimaAsync()
    {
        if (estaOcupado) return;

        estaOcupado = true;
        try
        {
            var localizacao = await Geolocation.Default.GetLocationAsync();
            if (localizacao != null)
            {
                var clima = await _servicoClima.ObterClimaAsync(localizacao.Latitude, localizacao.Longitude);
                if (clima != null)
                {
                    temperatura = $"{clima.Principal.Temperatura}°C";
                    descricao = clima.Descricoes.FirstOrDefault()?.Descricao ?? "Sem descrição";
                }
                else
                {
                    temperatura = "Erro ao obter clima.";
                    descricao = "Tente novamente.";
                }
            }
            else
            {
                temperatura = "Localização não encontrada.";
                descricao = "Verifique as permissões.";
            }
        }
        catch (Exception ex)
        {
            temperatura = "Erro ao buscar dados.";
            descricao = ex.Message;
        }
        finally
        {
            estaOcupado = false;
        }
    }
}
