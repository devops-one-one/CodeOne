import { Component, OnInit } from '@angular/core';

//declare function myMethod(): any;

@Component({
  selector: 'app-log-reg',
  templateUrl: './log-reg.component.html',
  styleUrls: ['./log-reg.component.scss']
})
export class LogRegComponent implements OnInit {
  isFavorite = false;

  constructor() { }

  ngOnInit(): void {
  }
  toggleClass(){
    if(this.isFavorite){
      this.isFavorite = false;
    }else{
      this.isFavorite = true;
    }
  }
}
