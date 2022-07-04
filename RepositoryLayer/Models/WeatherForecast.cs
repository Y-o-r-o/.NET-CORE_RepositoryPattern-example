namespace RepositoryLayer.Models;

public class WeatherForecast
{

    public Coord Coord { get; set; } = new();

    public List<Weather> Weather { get; set; } = new();

    public string Base { get; set; }

    public MainForecast Main { get; set; } = new();

    public int Visibility { get; set; }

    public Wind Wind { get; set; } = new();

    public Clouds Clouds { get; set; } = new();

    public int Dt { get; set; }

    public Sys Sys { get; set; } = new();

    public int Timezone { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Cod { get; set; }
}

public class Sys
{
    public int Type { get; set; }

    public int Id { get; set; }

    public string Country { get; set; }

    public int Sunrise { get; set; }

    public int Sunset { get; set; }
}

public class Weather
{
    public int Id { get; set; }

    public string Main { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }
}

public class Wind
{
    public double Speed { get; set; }

    public int Deg { get; set; }
}

public class Clouds
{
    public int All { get; set; }
}

public class Coord
{
    public double Lon { get; set; }

    public double Lat { get; set; }
}

public class MainForecast
{
    public double Temp { get; set; }

    public double FeelsLike { get; set; }

    public double TempMin { get; set; }

    public double TempMax { get; set; }

    public int Pressure { get; set; }

    public int Humidity { get; set; }
}