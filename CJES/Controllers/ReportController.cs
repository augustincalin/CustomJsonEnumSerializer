using CJES.Model;
using Microsoft.AspNetCore.Mvc;

namespace CJES.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reportRequest = new ReportRequest
            {
                Date = DateTime.Now,
                Category = Category.Condominium,
                Discriminator = "DE",
                ConstructionYear = 2001
            };
            /**
             *   please note that even if the internal representation of reportRequest is using the more generic notion of Condominium,
             *  when it's serialized, the more specific term of Eigentumswohnung is generated.
             **/
            return Ok(reportRequest);
        }

        [HttpPost]
        public IActionResult Save(ReportRequest reportRequest)
        {
            /**
             *    please note that even if the incoming reportRequest is using the more specific term of Eigentumswohnung,
             *   the value obtained after deserialization is using the more generic notion of Condominium.
             *   To see this, place a breakpoint on the next line and inspect the reportRequest.Category.
             *   Still, when you continue the execution you will see (in swagger, for example), the same Eigentumswohnung -- this is because the 
             *   deserialization happens again and Condominium is translated back into the original Eigentumswohnung.
             **/
            return Ok(reportRequest);
        }
    }
}