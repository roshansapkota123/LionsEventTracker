import { Component, OnInit } from '@angular/core';
import { SERVER_ROOT } from '../config';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  events: any[];
  subscribed = false;
  isAdmin = false;
  constructor(private http: HttpClient, private router: Router) {}

   ngOnInit() {
     const user = localStorage.getItem('user');
     if (!user) {
      return this.router.navigate(['/login']);
     }
     console.log('This is user');
   /*  console.log(JSON.parse(user)); */
     this.isAdmin = JSON.parse(user).isAdmin;

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

  subscribe() {
    console.log(this.subscribed);
    this.subscribed = !this.subscribed;
  }

}
