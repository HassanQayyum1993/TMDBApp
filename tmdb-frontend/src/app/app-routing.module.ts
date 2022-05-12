import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [{
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
  path: "movie/movieDetails/:movieId",
  loadChildren: () =>
    import("./movie-details/movie-details.module").then(
      (m) => m.MovieDetailsModule
    ),
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
