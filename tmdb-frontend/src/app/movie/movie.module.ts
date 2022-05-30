import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from "@angular/material/input";
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTabsModule } from '@angular/material/tabs';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MovieComponent } from './movie.component';
import { TopMoviesListComponent } from './top-movies-list/top-movies-list.component';
import { SearchMoviesComponent } from './search-movies/search-movies.component';
import { SharedModule } from 'app/shared-module/shared.module';
import { MovieService } from 'app/services/movie.service';
import { MatProgressBarModule } from "@angular/material/progress-bar";

const routes: Routes = [
  {
      path     : "",
      component: MovieComponent,
  }
]

@NgModule({
  declarations: [
    MovieComponent,
    TopMoviesListComponent,
    SearchMoviesComponent
  ],
  imports: [
        RouterModule.forChild(routes),
        CommonModule,
        MatTabsModule,
        MatCardModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatToolbarModule,
        MatSelectModule,
        MatPaginatorModule,
        MatTableModule,
        FormsModule,
        SharedModule,
        MatProgressBarModule,
  ],
  providers: [MovieService]
})
export class MovieModule { }
