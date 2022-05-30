import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'tmdb-frontend';
  selectedTabIndex: number;
  userName: string
  isLoggedIn = false;
  token: string
  constructor(private authenticationService: AuthenticationService,
    private router: Router) { }

  ngOnInit(): void {
    if(window.sessionStorage.getItem('auth-token')) {
      this.isLoggedIn = true;
    }
    if(window.sessionStorage.getItem('user-name')){
      this.userName = window.sessionStorage.getItem('user-name');
    }
  }

  goToLogInPage() {
    if (!window.sessionStorage.getItem('auth-token')) {
      this.router.navigateByUrl(`/login/fromMovieList`);
    }
  }

  logOut() {
    this.authenticationService.logout();
    this.isLoggedIn = false;
    this.userName='';
  }
}
