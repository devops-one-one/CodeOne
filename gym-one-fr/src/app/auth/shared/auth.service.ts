import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TokenDto} from "./token.dto";
import {BehaviorSubject, Observable, of} from "rxjs";
import {LoginDto} from "./login.dto";
import {environment} from "../../../environments/environment";
import {take, tap} from "rxjs/operators";
import {RegisterDto} from "./register.dto";


const jwtToken = 'jwtToken';
const userId = 'userId';
const email = 'email';
const userName = "userName"

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn$ = new BehaviorSubject<string | null>(this.getToken());
  isLoggedIn: boolean = false;

  constructor(private _http: HttpClient) { }


  login(loginDto: LoginDto): Observable<TokenDto>{
    return this._http.post<TokenDto>(environment.api+'/api/Auth/Login',loginDto)
      .pipe(
        tap(token =>{
          if(token && token.jwt){
            localStorage.setItem(jwtToken, token.jwt);
            localStorage.setItem(userId, token.userId.toString());
            localStorage.setItem(userName, token.userName);
            this.isLoggedIn$.next(token.jwt);
            this.isLoggedIn = true;
          }else {
            this.logout();
          }
        })
      )
  }

  logout(): Observable<boolean> {
    localStorage.removeItem(userId);
    localStorage.removeItem(jwtToken);
    localStorage.removeItem(email)
    this.isLoggedIn$.next(null);
    this.isLoggedIn = false;
    return of(true).pipe(take(1));
  }

  register(registerDto: RegisterDto): Observable<TokenDto>
  {
    return this._http.post<TokenDto>(environment.api+'/api/Auth/Register',registerDto)
      .pipe(
        tap(token =>{
          if(token && token.jwt){
            localStorage.setItem(jwtToken, token.jwt);
            localStorage.setItem(userId, token.userId.toString());
            localStorage.setItem(userName, token.userName);
            this.isLoggedIn$.next(token.jwt);
            this.isLoggedIn = true;
          }else {
            this.logout();
          }
        })
      )
  }
// you can use it if you want to show username :)
  getUserName(): string{
    var emailAsString = localStorage.getItem(userName);
    if(emailAsString) {
      return emailAsString;
    }
    return "";
  }
  // you can use it if you want to get the logged user data :)
  getUserId(): number{
    var userIdAsString = localStorage.getItem(userId);
    if(userIdAsString) {
      return +userIdAsString;
    }
    return -1
  }

  getToken(): string | null {
    return localStorage.getItem(jwtToken);
  }
}
