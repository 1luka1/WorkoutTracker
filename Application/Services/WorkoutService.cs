using Application.DTOs.Workout;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly ILogger<WorkoutService> _logger;

        public WorkoutService(IWorkoutRepository workoutRepository, ILogger<WorkoutService> logger  )
        {
            _workoutRepository = workoutRepository;
            _logger = logger;
        }

        public async Task<Result<WorkoutResponseDto>> AddAsync(CreateWorkoutDto dto, int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                var workout = new Workout(

                    userId,
                    dto.ExerciseType,
                    dto.DurationMinutes,
                    dto.CaloriesBurnt,
                    dto.WeightIntensity,
                    dto.Fatigue,
                    dto.Notes,
                    dto.WorkoutDateTime

                );

                await _workoutRepository.AddAsync(workout, cancellationToken);
                await _workoutRepository.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("New workout added for user {UserId} (ID: {WorkoutId})", userId, workout.Id);

                var response = new WorkoutResponseDto(

                    workout.Id,
                    workout.UserId,
                    workout.ExerciseType,
                    workout.DurationMinutes,
                    workout.CaloriesBurnt,
                    workout.WeightIntensity,
                    workout.Fatigue,
                    workout.Notes,
                    workout.WorkoutDateTime

                );

                return Result<WorkoutResponseDto>.Success(response);

            }
            catch (ArgumentException ex) {
                _logger.LogWarning(ex, "Workout validation unsuccessful for user {UserId}", userId);
                return Result<WorkoutResponseDto>.Failure(ex.Message);
            }
        }
    }
}
