import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Car } from 'src/app/models/car';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-card-trip',
  templateUrl: './card-trip.component.html',
  styleUrls: ['./card-trip.component.scss'],
})
export class CardTripComponent {
  @Input() car: Car;
  @Output() deleteRequest = new EventEmitter<number>();

  constructor(private authenticationSerivce : AuthenticationService)
  {}

  onDelete() {
    this.deleteRequest.emit(this.car.id);
  }
}
