using LinuxApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinuxApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Jwt _jwt;
        private readonly Mail _mail;
        private readonly Cloudinary _cloudinary;
        public WeatherForecastController(IOptions<Jwt> jwt, IOptions<Mail> mail, 
            IOptions<Cloudinary> cloudinary, IConfiguration configuration, ILogger<WeatherForecastController> logger)
        {
            _jwt = jwt.Value;
            _mail = mail.Value;
            _cloudinary = cloudinary.Value;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("loaferscreme")]
        public IEnumerable<WeatherForecast> Getters()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("environmentvariables")]
        public Response GetThem()
        {
            var conStr = _configuration.GetConnectionString("DefaultConnection");
            return new ()
            { 
                Cloudinary = _cloudinary,
                Mail = _mail,
                Jwt = _jwt,
                ConnectionString = conStr
            };
        }
    }

    public class Response
    {
        public Cloudinary Cloudinary { get; set; }
        public Jwt Jwt { get; set; }
        public Mail Mail { get; set; }
        public string ConnectionString { get; set; }
    }
}
