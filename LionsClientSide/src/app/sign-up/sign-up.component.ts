import { UserService } from './../share/user.service';
import { User } from '../share/user.model';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SERVER_ROOT } from '../config';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})

export class SignUpComponent  {
  constructor(private router: Router, private http: HttpClient ) {
}

user: User = new User;
emailPattern = '^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$';

signUpUser(e, form) {
      e.preventDefault();
      if (!form.valid) {
        return;
      }
      console.log(this.user);
      this.http.post<any>(`${SERVER_ROOT}/api/User/SignUp`, this.user).subscribe(
         response => {
           console.log(response);
         },
         data => {
        this.router.navigate(['/login']);
         }
         );
    }

}
