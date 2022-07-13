using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs;

public class MainForecastDTO
{
    /// <summary>
    /// Temperature
    /// </summary>
    /// <example>28.8</example>
    [Display(Name = "TemperatureCelsius")]
    public double TemperatureCelsius { get; set; }
}