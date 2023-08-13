using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Mvc;
using SupaWebApiClient.Models;

namespace SupaWebApiClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NetworkInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NetworkInfoModel networkInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NetworkInfos.Add(networkInfo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
