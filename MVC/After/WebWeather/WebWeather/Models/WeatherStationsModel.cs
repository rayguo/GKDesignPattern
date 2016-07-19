using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherLibrary;

namespace WebWeather.Models
{
    public class WeatherStationGroup
    {
        public string Name { get; set; }
        public IEnumerable<string> Stations { get; set; }
    }

    public class WeatherStationsModel
    {
        private IWeatherService service;

        public WeatherStationsModel(IWeatherService weatherService)
        {
            service = weatherService;
        }
        public IEnumerable<WeatherStationGroup> Stations
        {
            get
            {
                return from stationGroup in
                           (from station in service.GetWeatherStations()
                            group station by station.Substring(0, 1).ToUpper())
                       select new WeatherStationGroup
                       {
                           Name = stationGroup.Key,
                           Stations = stationGroup,
                       };

            }
        }
    }
}