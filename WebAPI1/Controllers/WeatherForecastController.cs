using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq; 
namespace WebAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        // Initialize document object
        // Initialize document object
        Document document = new Document();
        // Add page
        Page page = document.Pages.Add();
        // Add text to new page
        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Hello World!"));
// Save updated PDF
   document.Save("HelloWorld_out.pdf");

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PdfResult> Get()
        {
            Hmteam hmteam1 = new Hmteam();
            hmteam1.id = 1; hmteam1.name = "Home";
            hmteam1.delegation="delegation1";

            Awteam awteam1 = new Awteam();
            awteam1.id = 1; awteam1.name = "Home";
            awteam1.delegation = "delegation1";

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new PdfResult
            { gamename = "",
                gamedate = DateTime.Now,
                gamedateend = "10min",
                Time = "9:00",
                location = 1,
                hmteam = hmteam1,
                awteam = awteam1
                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            
           

        }
     


    }
}
