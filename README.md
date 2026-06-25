# Workout Tracker - Workout Tracking Application

A workout tracking application that allows users to log their workouts, track progress through weekly statistics, and manage their fitness goals.

---

## Technologies

### Backend (ASP.NET Core Web API)

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core (ORM) with PostgreSQL database
- JWT (JSON Web Tokens) for authentication
- BCrypt for password hashing
- Serilog for logging (to file and console)
- `Result<T>` pattern for explicit error handling

### Frontend (Angular)

- Angular 21 (Standalone components)
- Reactive Forms for input validation
- HTTP Interceptor for automatic JWT token injection

---

## Features

- **Registration and Login** - JWT authentication, BCrypt password hashing
- **Workout Logging** - Exercise type (Cardio/Strength/Flexibility), duration, calories, weight intensity (1-10), fatigue (1-10), notes, date/time
- **Progress Tracking** - Weekly grouping (1-5 weeks) displaying: total duration, workout count, average intensity, average fatigue
- **Validation** - Frontend and backend validation with clear error messages
- **Logging** - Serilog file logging with daily rotation

---

## Architecture

The project is organized into 4 layers following Clean Architecture principles:

| Layer | Description |
|-------|-------------|
| **Domain** | Entities (User, Workout), Enums (ExerciseType), `Result<T>` pattern. No external dependencies. |
| **Application** | Services (AuthService, WorkoutService), DTOs, repository interfaces. Depends only on Domain. |
| **Infrastructure** | Repository implementations (EF Core), DbContext, migrations, JWT generator. Depends on Application and Domain. |
| **WebAPI** | Controllers, DI configuration, Swagger/OpenAPI. Depends on Application and Infrastructure. |

### Key Architectural Decisions

- **Private setters in entities** - State changes only through constructors and methods
- **`Result<T>` pattern** - Explicit handling of expected errors instead of throwing exceptions
- **Repository pattern** - Database abstraction enabling easy replacement
- **Weekly statistics** - Simple math (day/7 + 1) for grouping, predictable and testable

---

## Running Locally

### Prerequisites

- .NET 8 SDK
- Node.js (version 18 or newer)
- PostgreSQL (version 14 or newer)
- Angular CLI (`npm install -g @angular/cli`)

---

### 1. PostgreSQL Setup

1. Install PostgreSQL (version 14 or newer)
2. Create a database named `WorkoutTrackerDb` (optional - migrations will create it)
3. Configure the connection string in `WebAPI/appsettings.Development.json`:

`{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=WorkoutTrackerDb;Username=postgres;Password=your_password"
  }
}`

---

### 2. Backend (.NET API)

Open terminal in the root folder (`WorkoutTracker`).

Run migrations:

`dotnet ef database update --project Infrastructure --startup-project WebAPI`

Start the API:

`cd WebAPI`
`dotnet run --launch-profile https`

- API will be available at: `https://localhost:7060`
- Swagger documentation: `https://localhost:7060/swagger`

---

### 3. Frontend (Angular)

Open a new terminal in the root folder (`WorkoutTracker`):

`cd workout-tracker-frontend`
`npm install`
`ng serve`

- Frontend will be available at: `http://localhost:4200`

---

## Demo Video
https://youtu.be/4eJrFhFClTk
---

## Notes

- Individual workout view - `GET /workouts/{id}` was not implemented because the task did not require viewing individual workouts, only logging them and aggregated statistics.

- Unit tests - Not implemented due to time constraints, but the architecture is designed for easy addition using Moq and xUnit.

---

## Author

Luka Tomić
