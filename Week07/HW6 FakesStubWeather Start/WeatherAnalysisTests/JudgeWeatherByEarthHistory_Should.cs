using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAnalysis.Fakes;
using FluentAssertions;
using SUT = WeatherAnalysis;
using TooColdException;

namespace WeatherAnalysisTests
{
    [TestClass]
    public class JudgeWeatherByEarthHistory_Should
    {
        [DataTestMethod]
        [DataRow (-100, "Colder than Earth")]
        [DataRow(60, "Hotter than Earth")]
        [DataRow(30, "Meh")]
        public void ReturnCorrectValue_WhenInputCorrect(double temperature, string expected)
        {
            //Arrange
            var weather = new StubIWeather()
            {
                GetTemperature = () => { return temperature; }
            };

            //Act
            var results = SUT.WeatherUtilities.JudgeWeatherByEarthHistory(weather);

            //Assert
            expected.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(-300)]
        [DataRow(-274)]
        [DataRow(-1000)]
        public void ReturnThrowException_WhenLessThan273(double temperature)
        {
            //Arrange
            var weather = new StubIWeather()
            {
                GetTemperature = () => { return temperature; }
            };
            string results = string.Empty;
            Action act = () => results = SUT.WeatherUtilities.JudgeWeatherByEarthHistory(weather);

            //Act

            //Assert
            act.Should().Throw<ColderThanAbsoluteZeroException>();
        }
    }
}
