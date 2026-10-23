import { Routes } from '@angular/router';
import { AuthPage } from './pages/auth/auth';
import { Home } from './pages/home/home';

export const routes: Routes = [
	{ path: '', pathMatch: 'full', redirectTo: 'login' },
	{ path: 'login', component: AuthPage, data: { register: false } },
	{ path: 'register', component: AuthPage, data: { register: true } },
	{ path: 'home', component: Home },
	{ path: '**', redirectTo: 'login' },
];
