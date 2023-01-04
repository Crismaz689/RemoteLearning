import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/_services/account.service';
import { IAccount } from '../models/account';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {

  allAccounts$: Observable<IAccount[]> | undefined;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.allAccounts$ = this.accountService.getAllAccounts();
  }

}
