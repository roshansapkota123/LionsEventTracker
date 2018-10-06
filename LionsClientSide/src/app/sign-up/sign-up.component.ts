import { User } from '../share/user.model';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user: User;
 emailPattern = '^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$';

 constructor() { }

  ngOnInit() {
    /* this.resetForm(); */
  }


/*
resetForm(form?: NgForm) {


  if (form != null) {
    form.reset();
    this.user = {
      FirstName: '',
      LastName: '',
      Email: '',
      UserName: '',
      Password: ''
      };
  }
 } */
}
