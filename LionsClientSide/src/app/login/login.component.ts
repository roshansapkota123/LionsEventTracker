import { HttpClient } from '@angular/common/http';
import { User } from './../share/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SERVER_ROOT } from '../config';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private router: Router, private http: HttpClient) {

   }

  user: User = new User;

  logInUser(e, form) {
      e.preventDefault();
      if (!form.valid) {
        return;
      }
      console.log(this.user);

      this.http.post<any>(`${SERVER_ROOT}/api/User/LogIn`, this.user).subscribe(
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

