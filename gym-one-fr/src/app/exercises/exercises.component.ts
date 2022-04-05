import { Component, OnInit } from '@angular/core';
import {ExerciseService} from "./shared/exercise.service";
import {ExerciseSetDto} from "./shared/exercise.set.dto";
import {distinct} from "rxjs/operators";
import {ExerciseDto} from "./shared/exercise.dto";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.scss']
})
export class ExercisesComponent implements OnInit {
  inputDate: any;
  exercises: ExerciseDto[] = [];

  constructor(private _exerciseService:ExerciseService) {
  }

  ngOnInit(): void {
    if (environment.production) {
      console.log("PRODUCTION")
    }else{
      console.log("DEVELOPMENT")
    }

    this.inputDate = this.currentDateAsString();
    this.loadExercises();
  }
  currentDateAsString():string{
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');
    var yyyy = today.getFullYear();

    return `${yyyy}-${mm}-${dd}`;
  }

  loadExercises():void{
    let allExercises:ExerciseDto[] = [];
    let allUserExercises: ExerciseDto[] = [];
    let allUserSets:ExerciseSetDto[] = [];
    this._exerciseService.getAllExercises().subscribe((response:ExerciseDto[]) => {
      //Gets all exercises from the db
      allExercises = response;

      this._exerciseService.getAllExerciseSets(1).pipe(distinct(value => value.exerciseId)).subscribe((response)=>{
        //Extracts exercises from user sets
        allUserExercises = response

        this._exerciseService.getAllExerciseSets(1).subscribe((response)=>{
          allUserSets = response;

          this.exercises = allExercises.filter(e => {
            return allUserExercises.some(item => item.exerciseId === e.exerciseId);
          });
          this.exercises.forEach(exerciseValue =>{
            allUserSets.forEach(setValue => {
              if(exerciseValue.exerciseId == setValue.exerciseId){
                if(exerciseValue.exerciseSet == null){
                exerciseValue.exerciseSet = [];
                }
                exerciseValue.exerciseSet.push(setValue)
              }
            });
          });
        });
      });
    });
  }

  onValueChanged() {
    var date = this.inputDate as Date;
    //TODO retrieve exercise sets by date from backend
  }
}
