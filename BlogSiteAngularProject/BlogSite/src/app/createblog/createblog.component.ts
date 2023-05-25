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
  blogUserDetails: blogdetails = new blogdetails();
  //tblShow: boolean = false;
  //filteredRecord: Array<AirlineInventory> = new Array<AirlineInventory>();
  //SearchAirlineList: Array<AirlineInventory> = new Array<AirlineInventory>();
  constructor(private _eventService: EventService, private _router: Router,public filterPanelService:FilterPanelService) {

  }

  ngOnInit(): void {
  }

  PostBlogDetails() {
    this.blogUserDetails.createdBy = Number(localStorage.getItem('userid'))!;
    console.log(this.blogUserDetails);
    this._eventService.SaveNewBlog(this.blogUserDetails).subscribe(res => this.SuccessGet(res), err => (console.log(err),this.ErrorGet(err)));
    //this._auth.registerUser(this.registerUserData).subscribe(res=>this.SuccessGet(res),res=>this.ErrorGet(res));  
    // this.filteredRecord = this.SearchAirlineList.filter(function (item) {
    //   return item.fromPlace == data.txtFromPlace || item.toPlace == data.txtToPlace || item.startDateTime==data.txtBoardingDate || item.flightNumber==data.txtFlightNumber;
    // });
    // console.log(this.filteredRecord);
    //this.tblShow = true;
  }

  SuccessGet(res:any){
    Swal.fire({  
      position: 'center',  
      icon: 'success',  
      text: 'Blog Added Successfully!'
    })
    this._router.navigate(['/viewblog'])
   // this.registerUserData=new UserData();  
  }
  ErrorGet(res:any){
    console.log(res);   
    Swal.fire({  
      position: 'center',  
      icon: 'error',  
      title: 'Oops...',  
      text: 'Something went wrong!'
    })  
  }
  // GoToBookFlight(flightDetails:any){
  //   this.filterPanelService.data = flightDetails;
  //   this._router.navigate(['/bookflight']);   
  // }

}
