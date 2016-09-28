using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using Models;

namespace Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public async Task WheaterFromGhent() 
        {
            ForecastIO forecast = await WeatherService.GetWeatherFromLatLng("51.039889", "3.725620");
            Assert.NotNull(forecast);
        }
    }
}
