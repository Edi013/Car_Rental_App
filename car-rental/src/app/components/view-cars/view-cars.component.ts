import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-view-cars',
  templateUrl: './view-cars.component.html',
  styleUrls: ['./view-cars.component.scss']
})
export class ViewCarsComponent implements OnInit {

  cars: Car[];

  constructor(private carService: CarService) { 
  }

  ngOnInit(): void {
    this.cars = []

    this.getAllCars();
  }
  
  async getAllCars(){
    this.cars = await this.carService.getAllCars();
  }
}
