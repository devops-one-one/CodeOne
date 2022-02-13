import {ExerciseSetDto} from "./exercise.set.dto";

import {Injectable} from "@angular/core";
@Injectable({
  providedIn: 'root'
})
export class ExerciseService {
  getExerciseSets(): ExerciseSetDto[]{
    return [{id: 1, exerciseName: "Eg", muscleGroupName: "Bicep", reps: 15, weight: 100, date: new Date()},
      {id: 2, exerciseName: "smth", muscleGroupName: "Legs", reps: 10, weight: 100, date: new Date()},
      {id: 3, exerciseName: "sd", muscleGroupName: "Bicep", reps: 15, weight: 100, date: new Date()},
      {id: 4, exerciseName: "sd", muscleGroupName: "Bicep", reps: 15, weight: 100, date: new Date()},
      {id: 5, exerciseName: "sd", muscleGroupName: "Bicep", reps: 15, weight: 100, date: new Date()}];
  }
}
