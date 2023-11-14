using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherService : IWeatherService
    {

        public string GetCity()
        {
            Console.WriteLine("Which city do wish to see the weather for?");
            var city = Console.ReadLine();

            return city;
        }

        public string PrintWeatherAndDay(string city, string weather, string dayOfWeek)
        {
            return ($"Today is {dayOfWeek}.\nThe weather in {city} {weather}");
        }

        public string GetDayOfWeek()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }
    }


    public interface IWeatherService
    {
        public string GetCity();
        public string PrintWeatherAndDay(string city, string weather, string dayOfWeek);
        public string GetDayOfWeek();
    }

    public interface IDatabase
    {
        public string GetWeather(int id);
    }

    public class Database : IDatabase
    {
        public string GetWeather(int id)
        {
            string[] weatherStrings = {
                "is gonna be sunny all day long.",
                "it's raining cat and dogs",
                "is unclear",
                "is a good day for eating apples",
                "is windy",
                "has local snowstorms"
            };
            var rand = new Random();
            var index = rand.Next(weatherStrings.Length);

            return weatherStrings[index];
        }
    }

    public class MockDatabase : IDatabase
    {
        public string GetWeather(int id) => "is gonna be sunny all day long.";
    }


    public class MockWeatherService : IWeatherService
    {
        public string GetDayOfWeek()
        {
            return "Friday";
        }

        public string GetCity()
        {
            return "Stockholm";
        }

        public string PrintWeatherAndDay(string city, string weather, string dayOfWeek)
        {
            return ($"The weather in {city} {weather}");
        }

    }
}
