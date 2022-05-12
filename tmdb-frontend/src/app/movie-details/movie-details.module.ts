import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatInputModule } from "@angular/material/input";
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMenuModule } from '@angular/material/menu';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { CdkTableModule } from '@angular/cdk/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTabsModule } from '@angular/material/tabs';
import { MovieDetailsComponent } from './movie-details.component';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MovieCommentsComponent } from './movie-comments/movie-comments.component';
import { MatGridListModule } from '@angular/material/grid-list'; 
import { SharedModule } from 'app/shared-module/shared.module';
import { MovieService } from 'app/services/movie.service';
import { CommentService } from 'app/services/comments.service';
const routes: Routes = [
  {
      path     : "",
      component: MovieDetailsComponent,
  }
]

@NgModule({
  declarations: [
    MovieDetailsComponent,
    MovieCommentsComponent
  ],
  imports: [
        RouterModule.forChild(routes),
        FormsModule,
        ReactiveFormsModule,
        MatGridListModule,
        FlexLayoutModule,
        CommonModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatTableModule,
        MatTabsModule,
        MatToolbarModule,
        MatSelectModule,
        MatPaginatorModule,
        MatCardModule,
        MatTableModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatTableModule,
        MatToolbarModule,
        MatSelectModule,
        MatPaginatorModule,
        MatTableModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatTableModule,
        MatToolbarModule,
        MatSelectModule,
        MatPaginatorModule,
        MatCardModule,
        MatTableModule,
        SharedModule
  ],
  providers: [MovieService, CommentService]
})
export class MovieDetailsModule { }
