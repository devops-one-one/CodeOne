import { Component, OnInit } from '@angular/core';
import {ExerciseService} from "./shared/exercise.service";
import {ExerciseSetDto} from "./shared/exercise.set.dto";

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.scss']
})
export class ExercisesComponent implements OnInit {
  inputDate: any;
  exerciseSets: ExerciseSetDto[] = [];

  constructor(private _exerciseService:ExerciseService) {
  }

  ngOnInit(): void {
    this.inputDate = this.currentDateAsString();
    this.exerciseSets = this._exerciseService.getExerciseSets();
  }
  currentDateAsString():string{
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');
    var yyyy = today.getFullYear();

    return `${yyyy}-${mm}-${dd}`;
  }

  onValueChanged() {
    var date = this.inputDate as Date;
    //TODO retrieve exercise sets by date from backend
  }
}
