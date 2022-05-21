//import { Component, OnInit } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthenticationService } from 'app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
// export class LoginComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }

// @Component({
//   templateUrl: 'login.html'
// })
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  submitClick = false;
  submitted = false;
  returnUrl: string;
  error = '';
  movieId: number;
  isFromMovieList = false;
  isLoading=false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    public matDialogRef: MatDialogRef<LoginComponent>,) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // reset login status
    this.authenticationService.logout();
    // get return url from route parameters or default to '/'
    if (this.route.snapshot.params.movieId) {
      this.movieId = +this.route.snapshot.params.movieId;
    }
    if (this.route.snapshot.params.fromMovieList == "fromMovieList") {
      this.isFromMovieList = true;
    }
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

  }

  // convenience getter for easy access to form fields
  get formData() { return this.loginForm.controls; }

  onLogin() {
    this.isLoading=true;
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.submitClick = true;
    this.authenticationService.login(this.formData.username.value, this.formData.password.value)
      .subscribe(
        response => {
          this.isLoading=false;
          this.matDialogRef.close(response);
        },
        error => {
          this.error = error;
          this.submitClick = false;
        });
  }
}
