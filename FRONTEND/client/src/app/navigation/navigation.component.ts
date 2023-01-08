import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, Subject, takeUntil } from 'rxjs';
import { IUser } from '../account/models/User';
import { RoleMapper } from '../_helpers/role-mapper';
import { Role } from '../_helpers/role.enum';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit, OnDestroy {
  currentUser$: Observable<IUser | null> = of(null);

  role = Role;

  destroy$ = new Subject<void>();

  userRole: Role = Role.Undefined;

  constructor(private accountService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.currentUser$.pipe(takeUntil(this.destroy$)).subscribe((user) => {
      if (user) {
        this.userRole = RoleMapper.RoleMapping(user?.roleName);
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
  }

  logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
