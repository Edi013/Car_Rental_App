import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-edit-car-details',
  templateUrl: './edit-car-details.component.html',
  styleUrls: ['./edit-car-details.component.scss']
})
export class EditCarDetailsComponent implements OnInit {

  constructor(private carService: CarService) {
   }

  ngOnInit(): void {
  }

  updateCar(){
    this.carService
  }

}
