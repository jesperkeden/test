namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var weatherService = new WeatherService();
            var db = new Database();
            var id = 3;


            var city = weatherService.GetCity();
            var weather = db.GetWeather(id);
            var dayOfWeek = weatherService.GetDayOfWeek();

            Console.WriteLine(weatherService.PrintWeatherAndDay(city, weather, dayOfWeek));
        }
    }
}