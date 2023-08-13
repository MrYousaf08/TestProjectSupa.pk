using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupaWebApi.Models;

namespace SupaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternetNetworkController : ControllerBase
    {
        private readonly DataContext _context;

        public InternetNetworkController(DataContext context)
        {
            _context = context;
        }

        // POST: api/InternetNetwork
        [HttpPost("CreateNetwork")]
        public async Task<IActionResult> StoreNetworkInformation(NetworkConfiguration input)
        {
            if (_context.NetworkConfigurations.Any(nc => nc.Networkcode == input.Networkcode))
            {
                return BadRequest(new { Message = "Network code already exists." });
            }

            var networkConfiguration = new NetworkConfiguration
            {
                NetworkLabelName = input.NetworkLabelName,
                Networkcode = input.Networkcode
            };

            _context.Add(networkConfiguration);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Network information stored successfully." });
        }

        // POST: api/InternetNetwork/submit
        [HttpPost("SerachNetwork")]
        public async Task<IActionResult> SubmitNetworkInformation(NetworkConfigurationInput input)
        {
            var networkConfiguration = await _context.NetworkConfigurations
                .FirstOrDefaultAsync(nc => nc.Networkcode == input.FourDigitCode && nc.NetworkLabelName == input.NetworkName);

            if (networkConfiguration != null)
            {
                return Ok(new { Message = "Network and code match. Redirect to page three." });
            }
            else
            {
                return BadRequest(new { Message = "Network or code is incorrect." });
            }
        }
    }
    public class NetworkConfigurationInput
    {
        public string NetworkName { get; set; }
        public string FourDigitCode { get; set; }
    }
}
