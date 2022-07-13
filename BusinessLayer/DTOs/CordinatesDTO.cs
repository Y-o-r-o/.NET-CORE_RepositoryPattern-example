using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs;

public class CordinatesDTO
{
    /// <summary>
    /// Latitude
    /// </summary>
    /// <example>54.687156</example>
    [Range(typeof(double), "-90", "90")]
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude
    /// </summary>
    /// <example>25.279651</example>
    [Range(typeof(double), "-180", "180")]
    public double Longitude { get; set; }
}