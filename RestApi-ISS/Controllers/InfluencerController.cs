using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : ControllerBase
    {
        private readonly InfluencerService influencerService;

        public InfluencerController(InfluencerService influencerService)
        {
            this.influencerService = influencerService;
        }

        [HttpGet("influencers")]
        public ActionResult<List<Influencer>> GetInfluencers()
        {
            try
            {
                var influencers = influencerService.GetInfluencers();
                return Ok(influencers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
