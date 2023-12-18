using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIAndJSON2
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var APIUrl = $"https://api.openweathermap.org/data/2.5/weather?q={KeysAndSuch.city},{KeysAndSuch.country}&appid={KeysAndSuch.APIKey}&units=imperial";

            var weatherResponse = client.GetStringAsync(APIUrl).Result;
            
            JObject responseFormatted = JObject.Parse(weatherResponse);
            
            var temp = responseFormatted["main"]["temp"];
            var feelsLike = responseFormatted["main"]["feels_like"];
            var description = responseFormatted["weather"][0]["description"];
            var wind = responseFormatted["wind"]["speed"];
            Console.WriteLine($"The current weather for {KeysAndSuch.city} is {temp} Degrees F (feels like {feelsLike}) with {description} and a {wind} mph wind.");
        }
    }
}
