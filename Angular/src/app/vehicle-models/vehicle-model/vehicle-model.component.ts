import { Component, OnInit } from '@angular/core';

import {VehicleModelService} from '../shared/vehicle-model.service'
import { NgForm } from '@angular/forms';

import{ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-vehicle-model',
  templateUrl: './vehicle-model.component.html',
  styleUrls: ['./vehicle-model.component.css']
})
export class VehicleModelComponent implements OnInit {

  constructor(private vehicleModelService : VehicleModelService, private toastr : ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm)
  {
      if(form != null)
        form.reset();
      this.vehicleModelService.selectedVehicleModel = {
      ID: null,
      Name: '',
      Color: '',
      Abrv: '',
    }
  }

  onSubmit(form : NgForm)
  {

    if(form.value.ID == null){
      this.vehicleModelService.postVehicleModel(form.value)
      .subscribe(data => { 
      this.resetForm(form);

      this.vehicleModelService.getVehicleModelList(); 

      this.toastr.success('New Vehicle Model added successfully!', 'Vehicle Model Register');
     })
    }
    else{
        this.vehicleModelService.putVehicleModel(form.value.ID, form.value)
        .subscribe(data => {
        this.resetForm(form);

        this.vehicleModelService.getVehicleModelList();

        this.toastr.info('Record updated successfully', 'Vehicle Model Register');
      })
    }

  }

}
