import * as _ from 'underscore'; 
import { SaveVehicle, Vehicle, KeyValuePair } from './../models/vehicle';

import { VehicleService } from '../../services/vehicle.service';

 
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { forkJoin } from 'rxjs';

//import {ToastyService, ToastyConfig, ToastOptions, ToastData} from 'ng2-toasty';



@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: ''
    }
    //features: [],
    //contact: {}
  };
  features: any[];
  vehicles: any[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    //private toastyService: ToastyService, 
    //private toastyConfig: ToastyConfig
    ) { 
     // this.toastyConfig.theme = 'material';
      route.params.subscribe(p => {
        //console.log('aa' + p['id']);
        this.vehicle.id = +p['id'] || 0;
     })
  }
 
  ngOnInit() {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures(),

    ];
    if(this.vehicle.id)
    sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    forkJoin(sources).subscribe(data => {
      this.makes = <any>data[0];
      this.features = <any>data[1];
      if(this.vehicle.id){
        
        this.setVehicle(<Vehicle>data[2]);
        this.populateModels();
      }
     
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
/*
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures(),
    ];

    if (this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    forkJoin(sources).subscribe(data => {
      this.makes = <any>data[0];
      this.features = <any>data[1];

      if (this.vehicle.id) {
        this.setVehicle(<Vehicle>data[2]);
        this.populateModels();
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });*/
  }

private setVehicle(v: Vehicle) {
  this.vehicle.id = v.id;
  this.vehicle.makeId = v.make.id;
  this.vehicle.modelId = v.model.id;
  this.vehicle.isRegistered = v.isRegistered;
  this.vehicle.contact = v.contact;
  this.vehicle.features = _.pluck(v.features, 'id');
} 

onMakeChange() {
  this.populateModels();

  delete this.vehicle.modelId;
}

private populateModels() {
  var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
  this.models = selectedMake ? selectedMake.models : [];
}

onFeatureToggle(featureId, $event) {
  if ($event.target.checked)
    this.vehicle.features.push(featureId);
  else {
    var index = this.vehicle.features.indexOf(featureId);
    this.vehicle.features.splice(index, 1);
  }
}
/*
addToast() {
  // Just add default Toast with title only
  this.toastyService.default('Hi there');
  // Or create the instance of ToastOptions
  var toastOptions:ToastOptions = {
      title: "My title",
      msg: "The message",
      showClose: true,
      timeout: 5000,
      theme: 'default',
      onAdd: (toast:ToastData) => {
          console.log('Toast ' + toast.id + ' has been added!');
      },
      onRemove: function(toast:ToastData) {
          console.log('Toast ' + toast.id + ' has been removed!');
      }
  }
  this.toastyService.info(toastOptions);
}*/



submit() {
  if (this.vehicle.id) {
    this.vehicleService.update(this.vehicle)
      .subscribe(x => {
        /*this.toastyService.success({
          title: 'Success', 
          msg: 'The vehicle was sucessfully updated.',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });*/
      console.log("updated" + x)});
  }
  else {
    
      this.vehicleService.create(this.vehicle)
      .subscribe(x => { console.log(x) });
  }
  
    //addToast() ;
   /* this.toastyService.success({
      title: 'Success', 
      msg: 'The vehicle was sucessfully updated.',
      theme: 'default',
      showClose: true,
      timeout: 5000
    })});*/
 
}

delete() {
  if (confirm("Are you sure?")) {
    this.vehicleService.delete(this.vehicle.id)
      .subscribe(x => {
        this.router.navigate(['/home']);
      });
  }
}
}