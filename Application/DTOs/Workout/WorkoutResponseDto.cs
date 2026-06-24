using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Workout
{
    public record WorkoutResponseDto(
        int Id,
        int UserId,
        ExerciseType ExerciseType,
        int DurationMinutes,
        int CaloriesBurnt,
        int WeightIntensity,
        int Fatigue,
        string? Notes,
        DateTime WorkoutDateTime
    );
}