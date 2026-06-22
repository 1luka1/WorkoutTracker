using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Workout
{
    public record CreateWorkoutDto (

        [Required(ErrorMessage = "Exercise type is required.")]
        [EnumDataType(typeof(ExerciseType), ErrorMessage = "Invalid exercise type.")]
        ExerciseType ExerciseType,

        [Required(ErrorMessage = "Duration minutes is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration minutes must be greater than 0.")]
        int DurationMinutes,

        [Range(1, int.MaxValue, ErrorMessage = "Calories burnt must be greater than 0.")]
        int CaloriesBurnt,

        [Range(1, 10, ErrorMessage = "Weight intensity must be between 1 and 10.")]
        int WeightIntensity,

        [Range(1, 10, ErrorMessage = "Fatigue must be between 1 and 10.")]
        int Fatigue,

        string? Notes,

        [Required(ErrorMessage = "Workout date and time is required.")]
        DateTime WorkoutDateTime


        );
    
}
