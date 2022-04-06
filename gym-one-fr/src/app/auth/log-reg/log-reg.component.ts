import { Component, OnInit } from '@angular/core';
import {LoginDto} from "../shared/login.dto";
import {FormBuilder, FormControl, Validators} from "@angular/forms";
import {AuthService} from "../shared/auth.service";
import {Router} from "@angular/router";
import {RegisterDto} from "../shared/register.dto";

@Component({
  selector: 'app-log-reg',
  templateUrl: './log-reg.component.html',
  styleUrls: ['./log-reg.component.scss']
})
export class LogRegComponent implements OnInit {
  isFavorite = false;

  loginForm = this._fb.group({

    email: new FormControl(
      '',
      [
        Validators.required,
      ]
    ),
    password: new FormControl(
      '',
      Validators.required
    ),
    errorText:['']
  });

  registerForm = this._fb.group({
    email: new FormControl(
      '',
      [
        Validators.required,
        Validators.maxLength(20)
      ]
    ),
    userName: new FormControl(
      '',
      [
        Validators.required,
        Validators.maxLength(20)
      ]
    ),
    password: new FormControl(
      '',
      [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(20)
      ]
    ),
  });

  constructor(private _fb: FormBuilder,
              private _auth: AuthService,
              private router: Router,) {}

  ngOnInit(): void {
  }


  toggleClass(){
    if(this.isFavorite){
      this.isFavorite = false;
    }else{
      this.isFavorite = true;
    }
  }

  login() {
    const loginDto = this.loginForm.value as LoginDto;
    this._auth.login(loginDto)
      .subscribe((token) =>{
        if (token&& token.jwt != null){
          console.log('Token: ',token.jwt);
          console.log("userId: ", token.userId)
          console.log("userName: ", token.userName)
        }else if (token && token.jwt == null){
          console.log('No token');
        }
      });
  }

  register() {
    const registerDto = this.registerForm.value as RegisterDto;
    this._auth.register(registerDto).subscribe(tokenDto=> {
      this.router.navigateByUrl("Feed me with some direction")
    });
  }

  get email() {return this.loginForm.get('email')}
  get password() {return this.loginForm.get('password')}
  get userName() {return this.registerForm.get('userName')}
}
