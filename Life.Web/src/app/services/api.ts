import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

export interface Homework {
  id: string | number;
  title: string;
  description?: string | null;
  dueDate?: string | null;
}

export interface HomeworkInput {
  title: string;
  description: string;
  dueDate: string | null;
}

export interface Credentials {
  name?: string;
  email: string;
  password: string;
}

interface AuthResponse {
  token?: string;
  accessToken?: string;
}

const API_BASE_URL = '/api';
const TOKEN_KEY = 'study-life-token';

@Injectable({ providedIn: 'root' })
export class ApiService {
  constructor(private readonly http: HttpClient) {}

  login(credentials: Credentials): Observable<AuthResponse | null> {
    return this.http.post<AuthResponse>(`${API_BASE_URL}/auth/login`, credentials).pipe(
      tap((response) => this.storeToken(response)),
    );
  }

  register(credentials: Credentials): Observable<AuthResponse | null> {
    return this.http.post<AuthResponse>(`${API_BASE_URL}/auth/register`, credentials).pipe(
      tap((response) => this.storeToken(response)),
    );
  }

  getHomeworks(): Observable<Homework[]> {
    return this.http.get<Homework[]>(`${API_BASE_URL}/homeworks`, {
      headers: this.authHeaders(),
    });
  }

  createHomework(homework: HomeworkInput): Observable<Homework> {
    return this.http.post<Homework>(`${API_BASE_URL}/homeworks`, homework, {
      headers: this.authHeaders(),
    });
  }

  logout(): void {
    localStorage.removeItem(TOKEN_KEY);
  }

  private storeToken(response: AuthResponse | null): void {
    if (!response) return;
    const token = response.accessToken ?? response.token;
    if (token) localStorage.setItem(TOKEN_KEY, token);
  }

  private authHeaders(): HttpHeaders {
    const token = localStorage.getItem(TOKEN_KEY);
    return token ? new HttpHeaders({ Authorization: `Bearer ${token}` }) : new HttpHeaders();
  }
}