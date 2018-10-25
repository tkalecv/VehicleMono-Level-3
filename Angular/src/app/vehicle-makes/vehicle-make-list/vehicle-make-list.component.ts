import { Component, OnInit } from '@angular/core';

import {VehicleMakeService} from '../shared/vehicle-make.service';
import{VehicleMake} from '../shared/vehicle-make.model';
import {ToastrService} from 'ngx-toastr'

@Component({
  selector: 'app-vehicle-make-list',
  templateUrl: './vehicle-make-list.component.html',
  styleUrls: ['./vehicle-make-list.component.css']
})
export class VehicleMakeListComponent implements OnInit {

  constructor(private vehicleMakeService : VehicleMakeService, private toastr : ToastrService) { }

  ngOnInit() {

    this.vehicleMakeService.getVehicleMakeList();
  }

  editVehicleMake(vMake : VehicleMake){

    this.vehicleMakeService.selectedVehicleMake = Object.assign({}, vMake);
  }

  deleteVehicleMake(id : number){
    if(confirm('Are you sure to delete this record?') == true){
    this.vehicleMakeService.deleteVehicleMake(id)
    .subscribe(x => {
      this.vehicleMakeService.getVehicleMakeList();
      this.toastr.warning("Deleted successfully!", "Vehicle Make Register");
    });
    }

  }

}
