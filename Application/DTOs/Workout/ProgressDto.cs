using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Workout
{
    public record ProgressDto(
        int WeekNumber,
        int TotalDuration,
        int WorkoutCount,
        double AverageIntensity,
        double AverageFatigue
    );
}