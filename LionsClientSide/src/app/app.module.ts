import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import {RouterModule, Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import {HttpClientModule} from '@angular/common/http';
import { ValueComponent } from './value/value.component';
import { EventcreateComponent } from './eventcreate/eventcreate.component';
import { LandingpageComponent } from './landingpage/landingpage.component';
const appRoutes: Routes = [
  {path: '', component: LandingpageComponent},
  { path: 'signup', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'landingpage', component: LandingpageComponent },

  { path: 'eventcreate', component: EventcreateComponent }

  // {path: '', redirectTo:'/log-in', pathMatch:'full' },

  ];



@NgModule({
   declarations: [
      AppComponent,
      SignUpComponent,
      LoginComponent,
      HomeComponent,
      ValueComponent,
      EventcreateComponent,
      LandingpageComponent
   ],
   imports: [
      BrowserModule,
      RouterModule.forRoot(appRoutes),
      FormsModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
