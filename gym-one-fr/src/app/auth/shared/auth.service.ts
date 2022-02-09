import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TokenDto} from "./token.dto";
import {BehaviorSubject, Observable, of} from "rxjs";
import {LoginDto} from "./login.dto";
import {environment} from "../../../environments/environment";
import {take, tap} from "rxjs/operators";


const jwtToken = 'jwtToken';
const userId = 'userId';
const username = 'username';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn$ = new BehaviorSubject<string | null>(this.getToken());
  isLoggedIn: boolean = false;

  constructor(private _http: HttpClient) { }


  login(loginDto: LoginDto): Observable<TokenDto>{
    return this._http.post<TokenDto>(environment.api+'/api/auth/Login',loginDto)
      .pipe(
        tap(token =>{
          if(token && token.jwt){
            localStorage.setItem(jwtToken, token.jwt);
            localStorage.setItem(userId, token.userId.toString());
            localStorage.setItem(username, loginDto.username.toString());
            this.isLoggedIn$.next(token.jwt);
            this.isLoggedIn = true;
          }else {
            this.logout();
          }
        })
      )
  }


  getToken(): string | null {
    return localStorage.getItem(jwtToken);
  }


  logout(): Observable<boolean> {
    localStorage.removeItem(userId);
    localStorage.removeItem(jwtToken);
    this.isLoggedIn$.next(null);
    this.isLoggedIn = false;
    return of(true).pipe(take(1));
  }
}
