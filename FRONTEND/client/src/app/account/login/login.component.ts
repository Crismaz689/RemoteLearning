import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { AccountService } from 'src/app/_services/account.service';
import { ILogin } from '../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  error: string = '';

  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,
    private snackBar: MatSnackBar,
    private router: Router) { 
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.accountService.currentUser$.pipe(
      map((user) => {
        if (user) {
          this.router.navigateByUrl('/homepage');
        }
      }));
  }

  login(): void {
    const credentials: ILogin = this.loginForm.getRawValue();

    this.accountService.login(credentials).subscribe((user)=> {
      if (user) {
        this.accountService.setUser(user);
        this.router.navigateByUrl('/homepage');
      }
    },
    (err) => {
      this.snackBar.open('Niepoprawne dane logowania!', '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
