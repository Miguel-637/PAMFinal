namespace WeatherApp.Models;

public class RespostaClima
{
    public ClimaPrincipal Principal { get; set; } = new ClimaPrincipal();
    public List<DescricaoClima> Descricoes { get; set; } = new List<DescricaoClima>();
}

public class ClimaPrincipal
{
    public double Temperatura { get; set; }
}

public class DescricaoClima
{
    public string Descricao { get; set; } = string.Empty;
}
