import { ProfileComponent } from './app/homepage/profile/profile.component';
import { CreateeventComponent } from './app/homepage/createevent/createevent.component';
import { ContactusComponent } from './app/homepage/contactus/contactus.component';
import { AboutusComponent } from './app/homepage/aboutus/aboutus.component';
import { HomepageComponent } from './app/homepage/homepage.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';






const routes: Routes = [

    {path: 'homepage', component: HomepageComponent},
    { path: '' , redirectTo: '/login', pathMatch: 'full' },
    { path: 'signup' , redirectTo: '/signup', pathMatch: 'full' },
    {path: 'signup', component: SignUpComponent},
    { path: 'aboutus', component: AboutusComponent},
  { path: 'contactus', component: ContactusComponent},
  { path: 'createevent', component: CreateeventComponent},
  { path: 'profile', component: ProfileComponent}

];
@NgModule({
    imports: [RouterModule.forRoot(routes), CommonModule],
    exports: [RouterModule]
})
export class AppRoutingModule {}
