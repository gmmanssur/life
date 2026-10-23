import { Component, OnInit, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ApiService, Homework } from '../../services/api';

@Component({
  imports: [DatePipe, FormsModule, RouterLink],
  selector: 'app-home',
  styleUrl: './home.css',
  templateUrl: './home.html',
})
export class Home implements OnInit {
  readonly todayLabel = new Intl.DateTimeFormat('pt-BR', {
    weekday: 'long',
    day: '2-digit',
    month: 'long',
  }).format(new Date()).toLocaleUpperCase();
  readonly homeworks = signal<Homework[]>([]);
  readonly loading = signal(true);
  readonly loadError = signal('');
  readonly createOpen = signal(false);
  readonly saving = signal(false);
  readonly saveError = signal('');
  readonly saved = signal(false);
  title = '';
  description = '';
  dueDate = '';

  constructor(private readonly api: ApiService, private readonly router: Router) {}

  ngOnInit(): void {
    this.loadHomeworks();
  }

  loadHomeworks(): void {
    this.loading.set(true);
    this.api.getHomeworks().subscribe({
      next: (items) => {
        this.homeworks.set(items);
        this.loading.set(false);
        this.loadError.set('');
      },
      error: () => {
        this.loading.set(false);
        this.loadError.set('Não foi possível carregar seus homeworks. Confira a conexão com a API.');
      },
    });
  }

  createHomework(): void {
    if (!this.title.trim()) return;
    this.saving.set(true);
    this.saveError.set('');
    this.saved.set(false);
    this.api.createHomework({
      title: this.title.trim(),
      description: this.description.trim(),
      dueDate: this.dueDate || null,
    }).subscribe({
      next: (homework) => {
        this.homeworks.update((items) => [homework, ...items]);
        this.title = '';
        this.description = '';
        this.dueDate = '';
        this.saving.set(false);
        this.createOpen.set(false);
        this.saved.set(true);
      },
      error: () => {
        this.saving.set(false);
        this.saveError.set('Não foi possível salvar. Verifique a API e tente novamente.');
      },
    });
  }

  logout(): void {
    this.api.logout();
    void this.router.navigateByUrl('/login');
  }
}
