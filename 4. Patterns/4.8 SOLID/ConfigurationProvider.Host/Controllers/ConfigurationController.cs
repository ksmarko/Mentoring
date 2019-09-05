using ConfigurationProvider.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationProvider.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationProvider _provider;

        public ConfigurationController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("service")]
        public ActionResult<ServiceSettings> GetServiceSettings([FromQuery] GetSettingsRequest request)
        {
            return _provider.GetConfiguration<ServiceSettings>(request.Environment);
        }

        [HttpGet("parser")]
        public ActionResult<ParsingSettings> GetParsingSettings([FromQuery] GetSettingsRequest request)
        {
            return _provider.GetConfiguration<ParsingSettings>(request.Environment);
        }
    }
}
