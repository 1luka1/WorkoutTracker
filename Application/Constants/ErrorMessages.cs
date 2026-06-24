using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class ErrorMessages
    {
        //USERS
        public const string InvalidEmailOrPassword = "Wrong email or password.";
        public const string InvalidEmail = "Wrong email.";
        public const string UserAlreadyExists = "User with this email already exists.";
        public const string EmailRequired = "Email is required.";
        public const string PasswordRequired = "Password is required.";
        public const string PasswordLength = "Password must be at least 4 characters long.";
        public const string FirstNameRequired = "First name is required.";
        public const string LastNameRequired = "Last name is required.";


        //JWT
        public const string JwtSecretError = "JWT Secret is not configured.";
        public const string JwtIssuerError = "JWT Issuer is not configured.";
        public const string JwtAudienceError = "JWT Audience is not configured.";
        public const string UserIdNotFound = "User ID not found in token.";


        //WORKOUT
        public const string ExerciseTypeRequired = "Exercise type is required.";
        public const string ExerciseTypeInvalid = "Invalid exercise type.";
        public const string DurationMinutesRequired = "Duration minutes is required.";
        public const string DurationMinutesInvalid = "Duration minutes must be greater than 0.";
        public const string CaloriesRange = "Calories burnt must be greater than 0.";
        public const string WeightIntensityRange = "Weight intensity must be between 1 and 10.";
        public const string FatigueRange = "Fatigue must be between 1 and 10.";
        public const string WorkoutDateTimeRequired = "Workout date and time is required.";
        public const string YearOrMonthInvalid = "Invalid year or month.";
    }
}