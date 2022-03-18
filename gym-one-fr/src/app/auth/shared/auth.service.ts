import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TokenDto} from "./token.dto";
import {BehaviorSubject, Observable, of} from "rxjs";
import {LoginDto} from "./login.dto";
import {environment} from "../../../environments/environment";
import {take, tap} from "rxjs/operators";


const jwtToken = 'jwtToken';
const userId = 'userId';
const email = 'email';

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
            localStorage.setItem(email, loginDto.email.toString());
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

  register(loginDto: LoginDto): Observable<TokenDto>
  {
    return this._http.post<TokenDto>(environment.api+'/api/Auth/Register',loginDto)
      .pipe(
        tap(token =>{
          if(token && token.jwt){
            localStorage.setItem(jwtToken, token.jwt);
            localStorage.setItem(userId, token.userId.toString());
            localStorage.setItem(email, loginDto.email.toString());
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
    var emailAsString = localStorage.getItem(email);
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
