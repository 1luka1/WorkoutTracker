using Application.DTOs.Workout;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Constants;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/workouts")]
    [Authorize]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        private readonly ILogger<WorkoutsController> _logger;

        public WorkoutsController(IWorkoutService workoutService, ILogger<WorkoutsController> logger)
        {
            _workoutService = workoutService;
            _logger = logger;
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException(ErrorMessages.UserIdNotFound);
            return int.Parse(userIdClaim);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkout([FromBody] CreateWorkoutDto dto)
        {
            var userId = GetUserId();
            var result = await _workoutService.AddAsync(dto, userId);

            if (result.IsFailure)
                return BadRequest(new { error = result.ErrorMessage });

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetProgress([FromQuery] int year, [FromQuery] int month)
        {
            if (year < 0 || month < 0 || month > 12)
                return BadRequest(new { error = ErrorMessages.YearOrMonthInvalid });
            var userId = GetUserId();
            var result = await _workoutService.GetWeeklyProgressASync(userId, year, month);

            if (result.IsFailure)
                return BadRequest(new { error = result.ErrorMessage });

            return Ok(result.Data);
        }
    }
}