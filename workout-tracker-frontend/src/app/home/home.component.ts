import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html'
})
export class HomeComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  email = this.authService.getEmail();

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}