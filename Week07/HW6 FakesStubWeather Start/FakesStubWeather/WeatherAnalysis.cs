using SpacecraftInterface;

namespace WeatherAnalysis
{
    public interface IWeather
    {
        double GetTemperature();
    }
    public class Weather : IWeather
    {
        public double GetTemperature()
        {
            return Telemetry.GetTempFromSpacecraft();
        }

    }

    public static class WeatherUtilities
    {
        public static string JudgeWeatherByWaterState(IWeather w)
        {
            double tempCelsius = w.GetTemperature();
            if(tempCelsius < -273)
            {
                throw new TooColdException.ColderThanAbsoluteZeroException();
            }
            else if(tempCelsius <= 0)
            {
                return ("Freezing");
            }
            else if(tempCelsius > 99)
            {
                return ("Boiling");
            }
            else
            {
                return ("Wet");
            }
        }

        public static string JudgeWeatherByEarthHistory(IWeather w)
        {
            double tempCelsius = w.GetTemperature();
            if (tempCelsius < -273)
            {
                throw new TooColdException.ColderThanAbsoluteZeroException();
            }
            else if (tempCelsius >= -273 && tempCelsius < -89)
            {
                return ("Colder than Earth");
            }
            else if (tempCelsius > 56)
            {
                return ("Hotter than Earth");
            }
            else if (tempCelsius >= -89 && tempCelsius <= 56)
            {
                return ("Meh");
            }
            else
            {
                return ("Inconclusive");
            }
        }
    }
}
