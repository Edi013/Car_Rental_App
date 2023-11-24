import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  constructor(private authenticationSerivce : AuthenticationService)
  {
  }
  
  ngOnInit(){
    this.imageUrl = 'assets/images/' + this.car.brand + '.jpg';
  }

}
