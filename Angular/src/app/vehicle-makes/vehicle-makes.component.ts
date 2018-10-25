import { Component, OnInit } from '@angular/core';

import{VehicleMakeService} from './shared/vehicle-make.service'

@Component({
  selector: 'app-vehicle-makes',
  templateUrl: './vehicle-makes.component.html',
  styleUrls: ['./vehicle-makes.component.css'],
  providers:[VehicleMakeService]
})
export class VehicleMakesComponent implements OnInit {

  constructor(private vehicleMakeService : VehicleMakeService) { }

  ngOnInit() {
  }

}
