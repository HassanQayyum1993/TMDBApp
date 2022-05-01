import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'app/authentication/authentication.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
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
