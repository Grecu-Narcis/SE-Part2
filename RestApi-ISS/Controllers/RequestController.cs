using Iss.Entity;
using Iss.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpGet("influencerId")]
        public ActionResult<string> GetInfluencers()
        {
            try
            {
                var influencerId = requestService.GetInfluencerId();
                return Ok(influencerId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("requestsForInfluencer")]
        public ActionResult<List<Request>> GetRequestForInfluencer()
        {
            try
            {
                var influencerRequests = requestService.GetRequestsForInfluencer();
                return Ok(influencerRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("requestsForAdAccount")]
        public ActionResult<List<Request>> GetRequestForAdAccount()
        {
            try
            {
                var adAccountsRequests = requestService.GetRequestsForAdAccount();
                return Ok(adAccountsRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("requestWithTitle/{title}")]
        public ActionResult<Request> GetRequestWithTitle(string title)
        {
            try
            {
                var requestWithTitle = requestService.GetRequestWithTitle(title);
                return Ok(requestWithTitle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("addRequest")]
        public ActionResult Login([FromBody] Request requestToAdd)
        {
            try
            {
                requestService.AddRequest(requestToAdd);
                return Ok("Request added successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("deleteRequest/{requestCollabName}")]
        public ActionResult DeleteRequest(string requestCollabName)
        {
            try
            {
                Request requestToDelete = requestService.GetRequestWithTitle(requestCollabName);
                requestService.DeleteRequest(requestToDelete);
                return Ok("Request was successfully deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("updateRequest")]
        public ActionResult UpdateRequest([FromBody] Request requestToUpdate, [FromBody] string newCompensation, [FromBody]string newContentRequirements)
        {
            try
            {
                requestService.UpdateRequest(requestToUpdate, newCompensation, newContentRequirements);
                return Ok("Request updated successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
