import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from 'src/app/_services/account.service';
import { ILogin } from '../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  error: string = '';

  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService) { 
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login(): void {
    const credentials: ILogin = this.loginForm.getRawValue();

    this.accountService.login(credentials).subscribe((response)=> {
      const user = response;

      if (user) {
        this.error = '';
        this.accountService.setSession(user);
        this.accountService.setCurrentUser(user);
      }
      else {
        this.error = 'Wprowadzono niepoprawne dane logowania!';
      }
    },
    (err) => {
      this.error = 'Wprowadzono niepoprawne dane logowania!';
    });
  }
}
