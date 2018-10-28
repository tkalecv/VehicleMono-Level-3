import { Injectable } from '@angular/core';

import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import  'rxjs/add/operator/toPromise';

import { map, filter, switchMap } from 'rxjs/operators';

import {VehicleModel} from './vehicle-model.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService {

  selectedVehicleModel : VehicleModel;
  vehicleModelList : VehicleModel[];

  constructor(private http : Http) { }

  postVehicleModel(vModel : VehicleModel)
  {
    var body = JSON.stringify(vModel);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post, headers : headerOptions});

   return this.http.post('http://localhost:51134/api/VehicleModel',
   body,
   requestOptions).map(x=>x.json());
  }

  getVehicleModelList()
  {
    this.http.get('http://localhost:51134/api/VehicleModel')
    .map((data: Response)=> 
    {return data.json() as VehicleModel[];
  }).toPromise().then(x => { 
    this.vehicleModelList = x;
  })
  }

  putVehicleModel(id, vModel)
  {
    var body = JSON.stringify(vModel);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Put, headers : headerOptions});

   return this.http.put('http://localhost:51134/api/VehicleModel/' + id,
    body, 
    requestOptions).map(x => x.json());
  }

  deleteVehicleModel(id : number){
    return this.http.delete('http://localhost:51134/api/VehicleModel/' + id).map(x => x.json());
  }

}
