import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {LiftsComponent} from "./lifts/lifts.component";
import {BodyComponent} from "./body/body.component";
import {LoginComponent} from "./login/login.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'lifts', component: LiftsComponent },
  { path: 'body', component: BodyComponent },
  { path: 'login', component: LoginComponent },

  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
