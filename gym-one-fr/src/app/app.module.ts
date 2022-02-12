import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { LiftsComponent } from './lifts/lifts.component';
import { BodyComponent } from './body/body.component';
import {HttpClientModule} from "@angular/common/http";
import { ExercisesComponent } from './exercises/exercises.component';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    LiftsComponent,
    BodyComponent,
    ExercisesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
