import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { CastDetailsComponent } from './movies/cast-details/cast-details.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path:"", component: HomeComponent },
  { path:"account/login", component: LoginComponent },
  { path:"account/register", component: RegisterComponent },

  { path:"movies", loadChildren: () => import("./movies/movies.module").then(m => m.MoviesModule), canLoad:[AuthGuard]},
  { path:"user", loadChildren: () => import("./user/user.module").then(mod => mod.UserModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
