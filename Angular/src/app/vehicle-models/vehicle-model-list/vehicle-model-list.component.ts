import { Component, OnInit } from '@angular/core';

import {VehicleModelService} from '../shared/vehicle-model.service';
import{VehicleModel} from '../shared/vehicle-model.model';
import {ToastrService} from 'ngx-toastr'


@Component({
  selector: 'app-vehicle-model-list',
  templateUrl: './vehicle-model-list.component.html',
  styleUrls: ['./vehicle-model-list.component.css']
})
export class VehicleModelListComponent implements OnInit {

  constructor(private vehicleModelService : VehicleModelService, private toastr : ToastrService) { }

  ngOnInit() {
    this.vehicleModelService.getVehicleModelList();
  }

  editVehicleModel(vModel : VehicleModel){

    this.vehicleModelService.selectedVehicleModel = Object.assign({}, vModel);
  }

  deleteVehicleMake(id : number){
    if(confirm('Are you sure to delete this record?') == true){
    this.vehicleModelService.deleteVehicleModel(id)
    .subscribe(x => {
      this.vehicleModelService.getVehicleModelList();
      this.toastr.warning("Deleted successfully!", "Vehicle Make Register");
    });
    }
  }


}
