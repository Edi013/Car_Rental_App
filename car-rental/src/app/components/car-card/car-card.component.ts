import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/models/car';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.scss'],
})
export class CarCardComponent implements OnInit{
  @Input() car: Car 
  imageUrl: string

  constructor(
    private authenticationSerivce : AuthenticationService,
    private router : Router)
  {
  }
  
  ngOnInit(){
    this.imageUrl = 'assets/images/' + this.car.brand + '.jpg';
  }

  navigateToEdit(){
    this.router.navigate(
      ["edit-car"],
     {
      queryParams: {
        id: this.car.id,
        brand: this.car.brand,
        model: this.car.model,
        type: this.car.type,
        price: this.car.price
      }
     }
    );
  }
}
