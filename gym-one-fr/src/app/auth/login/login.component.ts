import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, Validators} from '@angular/forms';
import {AuthService} from "../shared/auth.service";
import {LoginDto} from "../shared/login.dto";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

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

  constructor(private _fb: FormBuilder,
              private _auth: AuthService,) {}

  ngOnInit(): void {
  }


  login() {
    const loginDto = this.loginForm.value as LoginDto;
    this._auth.login(loginDto)
      .subscribe((token) =>{
        console.log('Test ');
        if (token&& token.jwt != null){
          console.log('Token: ',token.jwt);
        }else if (token && token.jwt == null){
          console.log('No token');
        }
      });
  }

  get email() {return this.loginForm.get('email')}
  get password() {return this.loginForm.get('password')}

}
