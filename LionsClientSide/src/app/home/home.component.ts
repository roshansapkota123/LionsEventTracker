import { Component, OnInit } from '@angular/core';
import { SERVER_ROOT } from '../config';
import { HttpClient } from '@angular/common/http';
import { Event } from '../shared/event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  events: any[];
  constructor(private http: HttpClient, private router: Router) {}

   ngOnInit() {
     const user = localStorage.getItem('user');
     if (!user) {
      return this.router.navigate(['/login']);
     }

    this.http.get<any>(`${SERVER_ROOT}/api/Events/getEvents`).subscribe(
      response => {
        this.events = response;
        console.log(this.events);
      }
    );
  }

  logout(e) {
    e.preventDefault();

    console.log('logging user out');
    localStorage.removeItem('user');
    return this.router.navigate(['/login']);

  }

}
