import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('TokenInfo')) {
      this.isLoggedIn = true;
    }
    if(localStorage.getItem('User')){
      this.userName = localStorage.getItem('User');
    }
  }

  goToLogInPage() {
    if (!localStorage.getItem('TokenInfo')) {
      this.router.navigateByUrl(`/login/fromMovieList`);
    }
  }

  logOut() {
    this.authenticationService.logout();
    this.isLoggedIn = false;
    this.userName='';
  }
}
