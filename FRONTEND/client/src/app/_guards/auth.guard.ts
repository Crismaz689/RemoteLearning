import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { RoleMapper } from '../_helpers/role-mapper';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService,
    private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot)
    : Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let url: string = state.url;

    return this.checkUserRole(next, url);
  }

  private checkUserRole(route: ActivatedRouteSnapshot, url: string) : boolean {
    if (route.data['role']) {
      const userRole = this.accountService.getRole();
      if (userRole === null) {
        this.router.navigateByUrl('');
        return false;
      } 

      const userRoleNumber = RoleMapper.RoleMapping(userRole);
      const routeRole = route.data['role'];
      const routeRoleNumber = RoleMapper.RoleMapping(routeRole);

      if (userRoleNumber >= routeRoleNumber) return true;
      else {
        this.accountService.currentUser$.pipe(
          map((user) => {
            if (user) {
              this.router.navigateByUrl('/homepage');
            }
            else {
              this.router.navigateByUrl('');
            }
          }
        ));
      }
    } 

    return false;
  }
}
