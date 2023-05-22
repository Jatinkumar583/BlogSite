import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { blogdetails } from '../models/blogdetails';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-viewblog',
  templateUrl: './viewblog.component.html',
  styleUrls: ['./viewblog.component.css']
})
export class ViewblogComponent implements OnInit {
  blogRecords: Array<blogdetails> = new Array<blogdetails>();
  constructor(private _eventService: EventService, private _router: Router) { }

  ngOnInit(): void {
    this._eventService.GetBlogsByUserIdList("BlognewCategory").subscribe(res => this.blogRecords = res, err => (console.log(err),this._router.navigate(['/login'])));
    console.log(this.blogRecords);
  }
  // GetScheduleFlights() {
  //   this._eventService.GetBlogsByUserIdList("BlognewCategory").subscribe(res => this.blogRecords = res, err => (console.log(err),this._router.navigate(['/login'])));
  //   // this.filteredRecord = this.SearchAirlineList.filter(function (item) {
  //   //   return item.fromPlace == data.txtFromPlace || item.toPlace == data.txtToPlace || item.startDateTime==data.txtBoardingDate || item.flightNumber==data.txtFlightNumber;
  //   // });
  //   console.log(this.blogRecords);
   
  // }
}
