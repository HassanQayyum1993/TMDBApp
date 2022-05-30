import { Component, OnInit } from '@angular/core';

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
  constructor() { }

  ngOnInit(): void {
    if (window.sessionStorage.getItem('auth-token')) {
      this.isLoggedIn = true;
    }
    if (window.sessionStorage.getItem('user-name')) {
      this.userName = window.sessionStorage.getItem('user-name');
    }
  }

}
