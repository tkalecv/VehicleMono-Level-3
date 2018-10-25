import { Injectable } from '@angular/core';

import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import  'rxjs/add/operator/toPromise';

import { map, filter, switchMap } from 'rxjs/operators';

import{VehicleMake} from './vehicle-make.model';

@Injectable(//{
  //providedIn: 'root'
//}
)
export class VehicleMakeService {

  selectedVehicleMake : VehicleMake;
  vehicleMakeList : VehicleMake[];

  constructor(private http : Http) { }

  postVehicleMake(vMake : VehicleMake)
  {
    var body = JSON.stringify(vMake);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post, headers : headerOptions});

   return this.http.post('http://localhost:51134/api/VehicleMake',
   body,
   requestOptions).map(x=>x.json());
  }

  getVehicleMakeList()
  {
    this.http.get('http://localhost:51134/api/VehicleMake')
    .map((data: Response)=> 
    {return data.json() as VehicleMake[];
  }).toPromise().then(x => { 
    this.vehicleMakeList = x;
  })
  }

  putVehicleMake(id, vMake)
  {
    var body = JSON.stringify(vMake);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Put, headers : headerOptions});

   return this.http.put('http://localhost:51134/api/VehicleMake/' + id,
    body, 
    requestOptions).map(x => x.json());
  }

  deleteVehicleMake(id : number){
    return this.http.delete('http://localhost:51134/api/VehicleMake/' + id).map(x => x.json());
  }
}


