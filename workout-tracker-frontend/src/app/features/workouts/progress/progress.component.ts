import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { WorkoutService } from '../../../core/services/workout.service';
import { WeeklyProgress } from '../../../core/models/workout.models';

@Component({
  selector: 'app-progress',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './progress.component.html'
})
export class ProgressComponent {
  private workoutService = inject(WorkoutService);

  selectedMonth = this.getCurrentMonthValue();
  progress: WeeklyProgress[] = [];
  errorMessage = '';
  isLoading = false;
  hasSearched = false;

  private getCurrentMonthValue(): string {
    const now = new Date();
    const month = (now.getMonth() + 1).toString().padStart(2, '0');
    return `${now.getFullYear()}-${month}`;
  }

  onSearch(): void {
    if (!this.selectedMonth) {
      return;
    }

    const [yearStr, monthStr] = this.selectedMonth.split('-');
    const year = Number(yearStr);
    const month = Number(monthStr);

    this.errorMessage = '';
    this.isLoading = true;
    this.hasSearched = true;

    this.workoutService.getMonthlyProgress(year, month).subscribe({
      next: (data) => {
        this.isLoading = false;
        this.progress = data;
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err?.error?.error || 'Failed to load progress. Please try again.';
      }
    });
  }
}