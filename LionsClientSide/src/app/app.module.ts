import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';


import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatToolbarModule, MatFormFieldModule, MatIconModule } from '@angular/material';
import { MaterialModule } from './material.module';
import { MatDividerModule } from '@angular/material';



import { AppComponent } from './app.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import {RouterModule, Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import {HttpClientModule} from '@angular/common/http';
import { ValueComponent } from './value/value.component';
import { HomepageComponent } from './app/homepage/homepage.component';
import { AppRoutingModule } from './app-routing.module';
import { AboutusComponent } from './app/homepage/aboutus/aboutus.component';
import { ProfileComponent } from './app/homepage/profile/profile.component';
import { CreateeventComponent } from './app/homepage/createevent/createevent.component';
import { ContactusComponent } from './app/homepage/contactus/contactus.component';

const appRoutes: Routes = [
  {path: '', component: LoginComponent},
  { path: 'signup', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: ' aboutus ', component: AboutusComponent},
  { path: ' contactus ', component: ContactusComponent},
  { path: ' createevent', component: CreateeventComponent},
  { path: ' profile ', component: ProfileComponent}

  // {path: '', redirectTo:'/log-in', pathMatch:'full' },

  ];



@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    LoginComponent,
    HomeComponent,
    ValueComponent,
    HomepageComponent,
    AboutusComponent,
    ProfileComponent,
    CreateeventComponent,
    ContactusComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    FlexLayoutModule,
    BrowserAnimationsModule,
    MatButtonModule, MatCheckboxModule,
    MaterialModule,
    MatToolbarModule,
    MatDividerModule,
    CommonModule,
    MatFormFieldModule,
    MatIconModule

    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
