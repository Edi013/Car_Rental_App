import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/login-request';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  showPassword: boolean = false;
  authenticationCredentials: LoginRequest = new LoginRequest();

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
  ) {}

  ngOnInit() {
    this.authenticationService.logout();
    
    this.loginForm = this.formBuilder.group({
      userName: [''],
      password: [''],
    });
  }

  async onLogin() {
    if (!this.loginForm.valid) {
      return;
    }

    try {
      console.log("am intrat pe try")
      let loginResponse = await this.authenticationService.login(
        this.authenticationCredentials
      );
      this.authenticationService
        .setIsUserAuthenticated(loginResponse);

      this.router.navigate(['']).then(()=>{
        window.location.reload();
      });
    } catch {
      this.loginForm.controls['userName'];
      this.loginForm.controls['password'];
      return;
    }
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  async submitLoginButton() {
    if (this.loginForm.valid) {
      this.loginForm.reset();
    }
  }

  getuserNameErrorMessage() {
    let userNameControl = this.loginForm.controls['userName'];
    return userNameControl.value == "" ?
       'User name required.'
       : '';
  }

  getPasswordErrorMessage() {
    let passwordControl = this.loginForm.controls['password'];
    return passwordControl.value == "" ?
    'Password required.'
    : '';
  }
}
