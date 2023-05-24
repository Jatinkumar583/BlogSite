import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AirlineInventory } from '../models/airlinedata';
import { blogdetails } from '../models/blogdetails';
import { BookingDetails } from '../models/bookingdetails';
import { PassengerDetails } from '../models/passengerdetails';
import { UserData } from '../models/UserData';
import { AuthService } from '../services/auth.service';
import { EventService } from '../services/event.service';
import { FilterPanelService } from '../services/filterpanel';

@Component({
  selector: 'app-createblog',
  templateUrl: './createblog.component.html',
  styleUrls: ['./createblog.component.css']
})
export class CreateblogComponent implements OnInit {
  //flightDetai
  tblShow: boolean = false;
  filteredRecord: Array<AirlineInventory> = new Array<AirlineInventory>();
  SearchAirlineList: Array<AirlineInventory> = new Array<AirlineInventory>();
  constructor(private _eventService: EventService, private _router: Router,public filterPanelService:FilterPanelService) {

  }

  ngOnInit(): void {
  }

  PostBlogDetails(data: any) {
    this._eventService.SaveNewBlog().subscribe(res => this.SearchAirlineList = res, err => (console.log(err),this._router.navigate(['/login'])));
    this.filteredRecord = this.SearchAirlineList.filter(function (item) {
      return item.fromPlace == data.txtFromPlace || item.toPlace == data.txtToPlace || item.startDateTime==data.txtBoardingDate || item.flightNumber==data.txtFlightNumber;
    });
    console.log(this.filteredRecord);
    //this.tblShow = true;
  }

  GoToBookFlight(flightDetails:any){
    this.filterPanelService.data = flightDetails;
    this._router.navigate(['/bookflight']);   
  }

}
