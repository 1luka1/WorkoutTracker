import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  CreateWorkoutRequest,
  WorkoutResponse,
  WeeklyProgress
} from '../models/workout.models';

const API_URL = `${environment.apiUrl}/workouts`;

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  constructor(private http: HttpClient) {}

  addWorkout(data: CreateWorkoutRequest): Observable<WorkoutResponse> {
    return this.http.post<WorkoutResponse>(API_URL, data);
  }

  getMonthlyProgress(year: number, month: number): Observable<WeeklyProgress[]> {
    return this.http.get<WeeklyProgress[]>(API_URL, { params: { year, month } });
  }
}