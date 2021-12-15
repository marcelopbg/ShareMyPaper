import { NgModule } from '@angular/core';
import type { Routes } from '@angular/router';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './auth/guard/auth.guard';
import { HomeComponent } from './home/home.component';
import { InstitutionComponent } from './institution/institution.component';
import { LoginComponent } from './login/login.component';
import { CreatePostComponent } from './post/create-post/create-post.component';
import { RegisterInstitutionModeratorComponent } from './register-institution-moderator/register-institution-moderator.component';
import { SignupComponent } from './signup/signup.component';
import { StudentsReviewComponent } from './students-review/students-review.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register-post', component: CreatePostComponent, canActivate: [AuthGuard], data: {roles: ['student']}},
  { path: 'students-review', component: StudentsReviewComponent, canActivate: [AuthGuard], data: { roles: ['institution moderator'] } },
  { path: 'institutions', component: InstitutionComponent, canActivate: [AuthGuard], data: { roles: ['admin', 'institution moderator'] } },
  { path: 'register-institution-moderator', component: RegisterInstitutionModeratorComponent, canActivate: [AuthGuard], data: { roles: ['admin', 'institution moderator'] } },
  { path: 'signup', component: SignupComponent }	
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
