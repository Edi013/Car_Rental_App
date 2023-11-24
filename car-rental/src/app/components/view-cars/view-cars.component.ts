import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'view-cars',
  templateUrl: './view-cars.component.html',
  styleUrls: ['./view-cars.component.scss']
})
export class ViewCarsComponent implements OnInit {

  cars: Car[];

  constructor(private carService: CarService) { 
  }

  async ngOnInit(): Promise<void> {
    this.cars = []

    await this.getAllCars();
  }
  
  async getAllCars(){
    await this.carService.getAllCars().then(x => this.cars = x);
  }
}
