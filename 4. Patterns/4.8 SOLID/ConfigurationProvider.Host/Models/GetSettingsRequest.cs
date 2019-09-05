using ConfigurationProvider.Models;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationProvider.Host.Models
{
    public class GetSettingsRequest
    {
        [Required]
        public EnvironmentType Environment { get; set; }
    }
}
