import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { WorkoutService } from '../../../core/services/workout.service';
import { ExerciseType } from '../../../core/models/workout.models';

@Component({
  selector: 'app-add-workout',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './add-workout.component.html'
})
export class AddWorkoutComponent {
  private fb = inject(FormBuilder);
  private workoutService = inject(WorkoutService);

  exerciseTypes = [
    { value: ExerciseType.Cardio, label: 'Cardio' },
    { value: ExerciseType.Strength, label: 'Strength' },
    { value: ExerciseType.Flexibility, label: 'Flexibility' }
  ];

  errorMessage = '';
  successMessage = '';
  isLoading = false;

  workoutForm = this.fb.group({
    exerciseType: [ExerciseType.Cardio, [Validators.required]],
    durationMinutes: [null as number | null, [Validators.required, Validators.min(1)]],
    caloriesBurnt: [null as number | null, [Validators.required, Validators.min(1)]],
    weightIntensity: [null as number | null, [Validators.required, Validators.min(1), Validators.max(10)]],
    fatigue: [null as number | null, [Validators.required, Validators.min(1), Validators.max(10)]],
    notes: [''],
    workoutDateTime: ['', [Validators.required]]
  });

  onSubmit(): void {
    if (this.workoutForm.invalid) {
      this.workoutForm.markAllAsTouched();
      return;
    }

    this.errorMessage = '';
    this.successMessage = '';
    this.isLoading = true;

    const formValue = this.workoutForm.value;

    const payload = {
      exerciseType: Number(formValue.exerciseType),
      durationMinutes: Number(formValue.durationMinutes),
      caloriesBurnt: Number(formValue.caloriesBurnt),
      weightIntensity: Number(formValue.weightIntensity),
      fatigue: Number(formValue.fatigue),
      notes: formValue.notes || null,
      workoutDateTime: new Date(formValue.workoutDateTime as string).toISOString()
    };

    this.workoutService.addWorkout(payload).subscribe({
      next: () => {
        this.isLoading = false;
        this.successMessage = 'Workout logged successfully.';
        this.workoutForm.reset({ exerciseType: ExerciseType.Cardio });
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err?.error?.error || 'Failed to log workout. Please try again.';
      }
    });
  }
}