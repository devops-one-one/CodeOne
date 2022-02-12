import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {LiftsComponent} from "./lifts/lifts.component";
import {BodyComponent} from "./body/body.component";
import {ExercisesComponent} from "./exercises/exercises.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'lifts', component: LiftsComponent },
  { path: 'body', component: BodyComponent },
  {path: 'exercises', component: ExercisesComponent},
  {
    path: "auth",
    loadChildren: () => import('./auth/auth.module')
      .then(f=>f.AuthModule)
  },

  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
