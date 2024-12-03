using CheckAlphabetWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CheckAlphabetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetCheckerController : ControllerBase
    {
        private readonly IAlphabetCheckerService _alphabetCheckerService;

        public AlphabetCheckerController(IAlphabetCheckerService alphabetCheckerService)
        {
            _alphabetCheckerService = alphabetCheckerService;
        }

        /// <summary>
        /// Checks if the input string contains all letters of the alphabet at least once.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <returns>True if all alphabet letters are found; otherwise, false.</returns>
        [HttpGet("check")]
        public IActionResult CheckAlphabet([FromQuery] string input)
        {
            if (string.IsNullOrEmpty(input))
                return BadRequest("Input string cannot be null or empty.");

            var result = _alphabetCheckerService.ContainsAllAlphabets(input);
            return Ok(result);
        }
    }
}
