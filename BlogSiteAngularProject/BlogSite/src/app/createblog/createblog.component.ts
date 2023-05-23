import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { blogdetails } from '../models/blogdetails';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-createblog',
  templateUrl: './createblog.component.html',
  styleUrls: ['./createblog.component.css']
})
export class CreateblogComponent implements OnInit {

  blogRecords: Array<blogdetails> = new Array<blogdetails>();
  constructor(private _eventService: EventService, private _router: Router) { }

  ngOnInit(): void {
    //this._eventService.GetBlogsByUserIdList("BlognewCategory").subscribe(res => this.blogRecords = res, err => (console.log(err),this._router.navigate(['/login'])));
    console.log(this.blogRecords);
  }

}
