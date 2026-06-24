using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Workout
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public ExerciseType ExerciseType { get; private set; }

        public int DurationMinutes { get; private set; }

        public int CaloriesBurnt { get; private set; }

        public int WeightIntensity { get; private set; }

        public int Fatigue { get; private set; }

        public string? Notes { get; private set; }

        public DateTime WorkoutDateTime { get; private set; }

        public User User { get; private set; }

        private Workout()
        {
        }

        public Workout(int userId, ExerciseType exerciseType, int durationMinutes, int caloriesBurnt,
            int weightIntensity, int fatigue, string? notes, DateTime workoutDateTime)
        {
            if (userId <= 0)
                throw new ArgumentException("UserId is required.", nameof(userId));

            if (durationMinutes < 0)
                throw new ArgumentException("Duration must be greater than 0.", nameof(durationMinutes));

            if (caloriesBurnt < 0)
                throw new ArgumentException("Calories burnt must be greater than 0.", nameof(caloriesBurnt));

            if (weightIntensity < 1 || weightIntensity > 10)
                throw new ArgumentException("Weight intensity must be between 1 and 10.", nameof(weightIntensity));

            if (fatigue < 1 || fatigue > 10)
                throw new ArgumentException("Fatigue must be between 1 and 10.", nameof(fatigue));

            UserId = userId;
            ExerciseType = exerciseType;
            DurationMinutes = durationMinutes;
            CaloriesBurnt = caloriesBurnt;
            WeightIntensity = weightIntensity;
            Fatigue = fatigue;
            Notes = notes;
            WorkoutDateTime = workoutDateTime;
        }
    }
}