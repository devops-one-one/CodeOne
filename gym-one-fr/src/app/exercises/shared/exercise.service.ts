import { ExerciseSetDto } from './exercise.set.dto';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { ExerciseDto } from './exercise.dto';

@Injectable({
  providedIn: 'root',
})
export class ExerciseService {
  constructor(private http: HttpClient) {}

  doStuff() {
    if (environment.production) {
      console.log('IS PRODUCTION');
      let url = '/config/api-url.txt';
      this.http.get(url, { responseType: 'text' }).subscribe((response) => {
        console.log('text' as 'json');
      });
    }
  }

  getAllExerciseSets(userId: number): Observable<any> {
    return this.http.get<ExerciseSetDto>(
      `${environment.api}/api/ExerciseSet?userId=${userId}`
    );
  }
  getAllExercises(): Observable<any> {
    return this.http.get<ExerciseDto>(`${environment.api}/Exercise`);
  }
}
