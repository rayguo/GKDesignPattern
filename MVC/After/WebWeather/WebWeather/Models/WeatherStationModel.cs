using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherLibrary;

namespace WebWeather.Models
{
    public class WeatherStationModel
    {
     
        private IWeatherService weatherService;
        
        private int page;
        private int pageSize;

        private List<WeatherSample> weatherSamples;

     

        public WeatherStationModel(IWeatherService weatherService, string station, int page, int pageSize)
        {
            // TODO: Complete member initialization
            this.weatherService = weatherService;
            Name = station;
            this.page = page;
            this.pageSize = pageSize;
            weatherSamples = weatherService.GetWeatherSamples(Name).ToList();
        }

        public string Name { get; private set; }

        public IEnumerable<WeatherSample> Samples
        {
            get { return weatherSamples.Skip( page * pageSize ).Take(pageSize) ; }

        }

        public int PageNumber { get { return page; } }
        public bool CanNext { get { return page * pageSize + pageSize < weatherSamples.Count; } }
        public bool CanPrev { get { return page > 0; } }
    }
}