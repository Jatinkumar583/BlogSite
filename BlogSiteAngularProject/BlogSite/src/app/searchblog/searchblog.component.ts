import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AirlineInventory } from '../models/airlinedata';
import { blogdetails } from '../models/blogdetails';
import { EventService } from '../services/event.service';
import { FilterPanelService } from '../services/filterpanel';

@Component({
  selector: 'app-searchblog',
  templateUrl: './searchblog.component.html',
  styleUrls: ['./searchblog.component.css']
})
export class SearchblogComponent implements OnInit {

  tblShow: boolean = false;
  //filteredRecord: Array<AirlineInventory> = new Array<AirlineInventory>();
  blogRecords: Array<blogdetails> = new Array<blogdetails>();
  //SearchAirlineList: Array<AirlineInventory> = new Array<AirlineInventory>();
  constructor(private _eventService: EventService, private _router: Router
    ,public filterPanelService:FilterPanelService) {

  }

  ngOnInit(): void {
  }

  GetBlogCategory(data: any) {
    this._eventService.GetBlogsByCategory(data.txtBlogCategory).subscribe(res => this.blogRecords = res, err => (console.log(err),this._router.navigate(['/login'])));
    // this.filteredRecord = this.SearchAirlineList.filter(function (item) {
    //   return item.fromPlace == data.txtFromPlace || item.toPlace == data.txtToPlace || item.startDateTime==data.txtBoardingDate || item.flightNumber==data.txtFlightNumber;
    // });
  }

  GoToBookFlight(flightDetails:any){
    this.filterPanelService.data = flightDetails;
    this._router.navigate(['/bookflight']);   
  }



}
