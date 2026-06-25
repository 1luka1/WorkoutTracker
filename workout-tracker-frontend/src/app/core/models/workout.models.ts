export enum ExerciseType {
  Cardio = 1,
  Strength = 2,
  Flexibility = 3
}

export interface CreateWorkoutRequest {
  exerciseType: ExerciseType;
  durationMinutes: number;
  caloriesBurnt: number;
  weightIntensity: number;
  fatigue: number;
  notes: string | null;
  workoutDateTime: string;
}

export interface WorkoutResponse {
  id: number;
  userId: number;
  exerciseType: ExerciseType;
  durationMinutes: number;
  caloriesBurnt: number;
  weightIntensity: number;
  fatigue: number;
  notes: string | null;
  workoutDateTime: string;
}

export interface WeeklyProgress {
  weekNumber: number;
  totalDuration: number;
  workoutCount: number;
  averageIntensity: number;
  averageFatigue: number;
}