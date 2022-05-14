import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'app/services/authentication.service';
import { LoginComponent } from 'app/shared-module/login/login.component';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {
  selectedTabIndex: number;
  userName: string
  isLoggedIn = false;
  token: string
  constructor(private authenticationService: AuthenticationService,
    private _matDialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    if (window.sessionStorage.getItem('token-info')) {
      this.isLoggedIn = true;
    }
    if (window.sessionStorage.getItem('user-name')) {
      this.userName = window.sessionStorage.getItem('user-name');
    }
  }

}
