using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Models;

public class Geocode
{
    public List<Result> Results { get; set; } = new();
    public string? Status { get; set; }
}

public class AddressComponent
{
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public List<string> Types { get; set; } = new();
}

public class Bounds
{
    public Northeast Northeast { get; set; } = new();
    public Southwest Southwest { get; set; } = new();
}

public class Geometry
{
    public Bounds Bounds { get; set; } = new();
    public Location Location { get; set; } = new();
    public string? LocationType { get; set; }
    public Viewport Viewport { get; set; } = new();
}

public class Location
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class Northeast
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class Result
{
    public List<AddressComponent> AddressComponents { get; set; } = new();
    public string? FormattedAddress { get; set; }
    public Geometry Geometry { get; set; } = new();
    public string? PlaceId { get; set; }
    public List<string> Types { get; set; } = new();
}

public class Southwest
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class Viewport
{
    public Northeast Northeast { get; set; } = new();
    public Southwest Southwest { get; set; } = new();
}

