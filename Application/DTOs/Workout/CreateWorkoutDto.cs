using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Constants;

namespace Application.DTOs.Workout
{
    public record CreateWorkoutDto(
        [Required(ErrorMessage = ErrorMessages.ExerciseTypeRequired)]
        [EnumDataType(typeof(ExerciseType), ErrorMessage = ErrorMessages.ExerciseTypeInvalid)]
        ExerciseType ExerciseType,
        [Required(ErrorMessage = ErrorMessages.DurationMinutesRequired)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.DurationMinutesInvalid)]
        int DurationMinutes,
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.CaloriesRange)]
        int CaloriesBurnt,
        [Range(1, 10, ErrorMessage = ErrorMessages.WeightIntensityRange)]
        int WeightIntensity,
        [Range(1, 10, ErrorMessage = ErrorMessages.FatigueRange)]
        int Fatigue,
        string? Notes,
        [Required(ErrorMessage = ErrorMessages.WorkoutDateTimeRequired)]
        DateTime WorkoutDateTime
    );
}