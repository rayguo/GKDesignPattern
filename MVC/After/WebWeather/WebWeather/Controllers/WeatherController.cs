using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWeather.Models;
using WeatherLibrary;

namespace WebWeather.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;
        //
        // GET: /Weather/
        public WeatherController()
        {
            weatherService = new CsvWeatherService(System.Web.HttpContext.Current.Server.MapPath("~/WeatherData"));
        }

        public ActionResult Index()
        {
            ViewData.Model = new WeatherStationsModel(weatherService);

            return View();
        }

        public ActionResult List(string id , int page = 0)
        {
            ViewData.Model = new WeatherStationModel(weatherService, id , page , 10 );

            return View();
        }

    }
}
