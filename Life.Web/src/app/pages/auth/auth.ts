import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ApiService } from '../../services/api';

@Component({
  imports: [FormsModule, RouterLink],
  selector: 'app-auth-page',
  styleUrl: './auth.css',
  templateUrl: './auth.html',
})
export class AuthPage {
  readonly registerMode = signal(false);
  readonly loading = signal(false);
  readonly error = signal('');
  readonly registered = signal(false);
  name = '';
  email = '';
  password = '';

  constructor(
    route: ActivatedRoute,
    private readonly api: ApiService,
    private readonly router: Router,
  ) {
    route.data.subscribe((data) => this.registerMode.set(data['register'] === true));
  }

  submit(): void {
    const isRegister = this.registerMode();
    this.loading.set(true);
    this.error.set('');
    const request = isRegister
      ? this.api.register({ name: this.name.trim(), email: this.email.trim(), password: this.password })
      : this.api.login({ email: this.email.trim(), password: this.password });

    request.subscribe({
      next: () => {
        this.loading.set(false);
        if (isRegister) {
          this.registered.set(true);
          return;
        }
        void this.router.navigateByUrl('/home');
      },
      error: () => {
        this.loading.set(false);
        this.error.set(isRegister
          ? 'Não foi possível criar sua conta. Confira os dados e tente novamente.'
          : 'E-mail ou senha inválidos. Confira seus dados e tente novamente.');
      },
    });
  }
}