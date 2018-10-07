import { SignUpComponent } from './../sign-up/sign-up.component';
import { LoginComponent } from './../login/login.component';
import { HomepageComponent } from './homepage/homepage.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';


const routes: Routes = [
    {path: 'homepage', component: HomepageComponent},
    {path: '', component: LoginComponent},
    {path: 'signup', component: SignUpComponent}
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
