using System;

namespace WeatherApp.Test
{
    public class WeatherServiceTests
    {

        // Datetime
        // CW + CR
        // Interface på WeatherService (getweather, getcity, printmessage)

        //var city = _weatherService.GetCity()
        //var day = _weatherService.GetDayOfWeek()
        //var weather = _weatherService.GetWeather()


        [Fact]
        public void PrintCorrectData()
        {
            // Arrange
            var db = new MockDatabase();
            var weatherService = new WeatherService();
            var weather = db.GetWeather(1);
            var day = weatherService.GetDayOfWeek();
            var city = "Stockholm";
            var expected = ($"Today is {day}.\nThe weather in {city} {weather}");

            // Act
            var actual = weatherService.PrintWeatherAndDay(city, weather, day);

            // Assert
            Assert.Equal( expected, actual );
        }
    }
}