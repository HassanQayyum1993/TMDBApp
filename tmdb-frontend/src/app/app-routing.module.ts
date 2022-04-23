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
      import("./movie/movie.module").then(
          (m) => m.MovieModule
      ),
},
{
  path: "movieDetails/:movieId",
  loadChildren: () =>
      import("./movie-details/movie-details.module").then(
          (m) => m.MovieDetailsModule
      ),
},
{
  path: "login/:movieId",
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
