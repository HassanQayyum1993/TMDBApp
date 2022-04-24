import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [  {
  path: '',
  pathMatch: 'full',
  redirectTo: 'movie'
},
{
  path: "movie",
  loadChildren: () =>
      import("./movie-main/movie-main.module").then(
          (m) => m.MovieMainModule
      ),
},
{
  path: "login/:fromMovieComments/:movieId",
  loadChildren: () =>
      import("./login/login.module").then(
          (m) => m.LoginModule
      ),
},
{
  path: "login/:fromMovieList",
  loadChildren: () =>
      import("./login/login.module").then(
          (m) => m.LoginModule
      ),
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
