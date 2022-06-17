namespace BusinessLayer.Helpers;

public static class Converter
{
    public static double KelvinToCelsius(double celsius) 
    {
        double diffRatio = 273.15;
        return celsius - diffRatio;
    }
}
