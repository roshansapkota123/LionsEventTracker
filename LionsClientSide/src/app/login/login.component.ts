import { HttpClient } from '@angular/common/http';
import { User } from './../share/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private http: HttpClient) { }

  user: User;

  ngOnInit() {
      }

  logInUser(e) {
      e.preventDefault();
      console.log(e);
      const password = e.target.elements[1].value;
      const Username = e.target.elements[0].value;
      this.http.post<any>('https://localhost:44304/api/user/login',
       {'Username': Username, 'password': password}).subscribe(
         response => {
           console.log(response);
         }
       );

      /*
      if ( Username === 'lion' && password === 'lion') {
        this.router.navigate(['home']);
      } else {
        this.router.navigate(['login']);
      } */
    }
    }

