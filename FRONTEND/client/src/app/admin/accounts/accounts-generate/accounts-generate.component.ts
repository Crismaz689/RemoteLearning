import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';
import { ICreateAccount } from '../../models/account-create';

@Component({
  selector: 'app-accounts-generate',
  templateUrl: './accounts-generate.component.html',
  styleUrls: ['./accounts-generate.component.scss']
})
export class AccountsGenerateComponent implements OnInit {

  createAccountForm: FormGroup;

  accountsToCreate: ICreateAccount[] = [];

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private snackBar: MatSnackBar) { 
    this.createAccountForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(3)]],
      surname: ['', [Validators.required, Validators.minLength(3)]],
      pesel: ['', [Validators.required, Validators.minLength(11)]],
      birthdayDate: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      roleId: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    document.getElementById("firstName")?.focus();
  }

  addAccount(): void {
    const newAccount: ICreateAccount = this.createAccountForm.getRawValue();
    this.accountsToCreate.push(newAccount);
    this.createAccountForm.reset();
  }

  createAccounts(): void {
    this.accountService.createAccounts(this.accountsToCreate).subscribe((course) => {
      if (course) {
        this.snackBar.open("Konta zostały stworzone. Na podane adresy email zostały wysłane dane do logowania.", '', { panelClass: ['text-white', 'bg-success'] });
        this.router.navigateByUrl('/admin/accounts');
      }
      else {
        this.snackBar.open("Nie udało sie utworzyć kont. Upewnij się, że nie istnieje już użytkownik z podanym adresem email oraz czy PESEL jest poprawny.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
        this.snackBar.open("Nie udało sie utworzyć kont. Upewnij się, że nie istnieje już użytkownik z podanym adresem email oraz czy PESEL jest poprawny.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
   
  }
}