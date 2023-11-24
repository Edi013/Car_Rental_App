import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-your-component',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  userLoggedIn: boolean = false;

  constructor(private router: Router, private authService: AuthenticationService) { }

  ngOnInit() {
    this.authService.isUserAuthenticatedSubject.subscribe((isLoggedIn: boolean) => {
      this.userLoggedIn = isLoggedIn;
    });
  }

  navigateToLogIn() {
    this.router.navigate(['/login']);
  }

  navigateToViewCars() {
    if(this.userLoggedIn == false){
      prompt("Log in first.")
      return;
    }
    this.router.navigate(['/view-cars']);
  }

}
