import { Component, OnInit } from '@angular/core';

import {VehicleMakeService} from '../shared/vehicle-make.service'
import { NgForm } from '@angular/forms';

import{ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-vehicle-make',
  templateUrl: './vehicle-make.component.html',
  styleUrls: ['./vehicle-make.component.css']
})
export class VehicleMakeComponent implements OnInit {

  constructor(private vehicleMakeService : VehicleMakeService, private toastr : ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm)
  {
      if(form != null)
        form.reset();
      this.vehicleMakeService.selectedVehicleMake = {
      ID: null,
      Name: '',
      Abrv: ''
    }
  }

  onSubmit(form : NgForm)
  {

    if(form.value.ID == null){
      this.vehicleMakeService.postVehicleMake(form.value)
      .subscribe(data => { 
      this.resetForm(form);

      this.vehicleMakeService.getVehicleMakeList(); 

      this.toastr.success('New Vehicle Make added successfully!', 'Vehicle Make Register');
     })
    }
    else{
        this.vehicleMakeService.putVehicleMake(form.value.ID, form.value)
        .subscribe(data => {
        this.resetForm(form);

        this.vehicleMakeService.getVehicleMakeList();

        this.toastr.info('Record updated successfully', 'Vehicle Make Register');
      })
    }

  }

}
