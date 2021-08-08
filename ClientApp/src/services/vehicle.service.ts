import { Vehicle } from './../app/models/vehicle';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { SaveVehicle } from '../app/models/vehicle';
//import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {
  private readonly vehiclesEndPoint = '/api/vehicles/';

  constructor(private http: HttpClient) { }

  getFeatures() {
    return this.http.get('/api/features')
      .pipe(map(res => res || []));
  }

  getMakes() {
    return this.http.get('/api/makes')
      .pipe(map(res => res  || [] ));
  }

  create(vehicle) {
    return this.http.post(this.vehiclesEndPoint, vehicle)
    .pipe(map(res => res  || [] ));
  }

  getVehicle(id) {
    return this.http.get(this.vehiclesEndPoint + id)
    .pipe(map(res => res  || [] ));
  }

  getVehicles(filter) {
    return this.http.get(this.vehiclesEndPoint + '?' + this.toQueryString(filter))
    .pipe(map(res => res  || [] ));
  }

  toQueryString(obj){
    var parts = [];
    for(var property in obj){
      var value = obj[property];
    if(value != null && value != undefined){
      parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }
   
    }
    return parts.join('&');
  }


  update(vehicle: SaveVehicle) {
    return this.http.put(this.vehiclesEndPoint + vehicle.id, vehicle)
    .pipe(map(res => res  || [] ));
  }

  delete(id) {
    return this.http.delete(this.vehiclesEndPoint + id)
    .pipe(map(res => res  || [] ));
  }
}
