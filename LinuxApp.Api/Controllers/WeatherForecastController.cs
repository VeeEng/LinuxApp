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
            var tenant = _configuration["Finbuckle:MultiTenant:Stores:ConfigurationStore:Tenants:1:Identifier"];
            return new ()
            { 
                Cloudinary = _cloudinary,
                Mail = _mail,
                Jwtters = _jwt,
                ConnectionString = conStr,
                Tenant = tenant
            };
        }
    }

    public class Response
    {
        public Cloudinary Cloudinary { get; set; }
        public Jwt Jwtters { get; set; }
        public Mail Mail { get; set; }
        public string ConnectionString { get; set; }
        public string Tenant { get; set; }
    }
}
