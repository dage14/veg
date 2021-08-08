import { Component, OnInit } from '@angular/core';
//import { Vehicle, KeyValuePair } from './../../models/vehicle';
import {KeyValuePair, Vehicle} from './../models/vehicle'
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  private readonly PAGE_SIZE = 3; 
  queryResult: any = {};
  
  //allVehicles: Vehicle[];
  makes: KeyValuePair[];

  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title : 'Id' , key: 'id' ,isSortable: false},
    { title: 'Contact name', key: 'contactName', isSortable: true},
    { title: 'Make', key: 'make', isSortable: true},
    { title: 'Model', key: 'model', isSortable: true},
    { isSortable: false}
  ];

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes()
    .subscribe(makes => this.makes = <any>makes);
    this.populateVehicles();



  // this.vehicleService.getVehicles(this.query)
   //.subscribe(vehicles => this.vehicles = this.allVehicles = <Vehicle[]>vehicles);

   //this.vehicleService.getVehicles()
   //.subscribe(vehicles => this.allVehicles = <Vehicle[]>vehicles);


   //this.allVehicles = this.vehicles;
   //this.query.makeId = this.vehicles.find(v => v.make.id);
 //  this.query = this.makes;
  }

  onFilterChange(){
   // this.query.ModelId = 2;
   this.query.page = 1; 
    this.populateVehicles();

  }

  private populateVehicles(){
    //this.vehicleService.getVehicles(this.query)
    //.subscribe(vehicles => this.vehicles = <Vehicle[]>vehicles);
    this.vehicleService.getVehicles(this.query)
    .subscribe(result => {
      this.queryResult = result;
      //this.totalItems = result.totalItems;
    });

  }
  /*
  onqueryChange(){
    
    var vehicles = this.allVehicles;
    //console.log(this.query.makeId);
    if(this.query.makeId)
    vehicles = vehicles.query(v => v.make.id == this.query.makeId);

    if(this.query.modelId)
    vehicles = vehicles.query(v => v.model.id == this.query.modelId);

    this.vehicles = vehicles;
  }*/

  resetquery(){
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.onFilterChange();
  }

  sortBy(columnName){
    if (this.query.sortBy === columnName){
    this.query.isSortAscending = !this.query.isSortAscending;

    }
    else{
      this.query.sortBy = columnName;
      this.query.isSortAscending = false;
    }

    this.populateVehicles();
  }

  onPageChange(page){
    this.query.page = page;
    this.populateVehicles();
  }

}
