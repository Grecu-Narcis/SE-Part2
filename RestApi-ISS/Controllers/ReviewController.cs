using Backend.Models;
using Iss.Entity;
using Iss.Service;
using Iss.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestApi_ISS.Controllers
{
    public class AddReviewRequest
    {
        public string User { get; set; }

        public string Review { get; set; }
    }

    public class UpdateReviewRequest
    {
        public string User { get; set; }

        public string Review { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceReview reviewService;

        public ReviewController(IServiceReview adSetService)
        {
            this.reviewService = adSetService;
        }

        [HttpPost("add")]
        public IActionResult AddReview([FromBody] AddReviewRequest addReviewRequest)
        {
            try
            {
                if (addReviewRequest == null || string.IsNullOrEmpty(addReviewRequest.Review))
                {
                    return BadRequest("Invalid review request.");
                }

                reviewService.AddReview(addReviewRequest.Review);
                return Ok("Review added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add review: {ex.Message}");
            }
        }

        [HttpGet("getallReviews")]
        public IActionResult GetReviews()
        {
            try
            {
                var retrievedAdSet = reviewService.GetAllReviews();
                if (retrievedAdSet == null)
                {
                    return NotFound("Ad set not found.");
                }
                return Ok(retrievedAdSet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to get reviews set: {ex.Message}");
            }
        }
    }
}
