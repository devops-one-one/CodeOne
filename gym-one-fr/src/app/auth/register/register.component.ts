import { Component, OnInit } from '@angular/core';
import {LoginDto} from "../shared/login.dto";
import {FormBuilder, FormControl, Validators} from "@angular/forms";
import {AuthService} from "../shared/auth.service";
import {Router} from "@angular/router";
import {RegisterDto} from "../shared/register.dto";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm = this.fb.group({
    email: new FormControl(
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

  constructor(private fb: FormBuilder,
              private _auth: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    const registerDto = this.registerForm.value as RegisterDto;
    this._auth.register(registerDto).subscribe(tokenDto=> {
      this.router.navigateByUrl("Feed me with some direction")
    });
  }

// you can use them to show some message if any Validators are missing.
  get email() {return this.registerForm.get('email')}
  get password() {return this.registerForm.get('password')}
}
