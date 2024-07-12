import { Routes } from '@angular/router';
import { RegisterComponent } from './routes/register/register.component';

export const routes: Routes = [
  // { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'auth/register', component: RegisterComponent },
];
