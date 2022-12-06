import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { IUser } from '../account/models/User';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  currentUser$: Observable<IUser | null> = of(null);

  constructor(private accountService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
