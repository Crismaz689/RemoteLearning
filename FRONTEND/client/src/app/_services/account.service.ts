import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ILogin } from '../account/models/login';
import { IUser } from '../account/models/User';
import { IAccount } from '../admin/models/account';
import { ICreateAccount } from '../admin/models/account-create';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private currentUserSource = new BehaviorSubject<IUser | null>(null);

  url: string = 'https://localhost:7271/rl/';

  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  getAllAccounts(): Observable<IAccount[]> {
    return this.http.get<IAccount[]>(this.url + 'accounts/');
  }

  deleteAccount(accountId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + 'accounts/' + accountId);
  }

  createAccounts(accounts: ICreateAccount[]): Observable<boolean> {
    return this.http.post<boolean>(this.url + 'accounts/', accounts);
  }

  login(credentials: ILogin): Observable<IUser> {
    return this.http.post<IUser>(this.url + 'accounts/login', credentials);
  }

  logout(): void {
    localStorage.clear();
    this.currentUserSource.next(null);
  }

  autoLogin(): void {
    if (localStorage.getItem("user") !== null) {
      const user : IUser = JSON.parse(localStorage.getItem("user")!);
      this.setCurrentUser(user);
    }
  }

  getRole(): string | null {
    if (localStorage.getItem("user") !== null) {
      const user : IUser = JSON.parse(localStorage.getItem("user")!);
      return user.roleName;
    }

    return null;
  }

  setUser(user: IUser): void {
    this.setSession(user);
    this.setCurrentUser(user);
  }

  private setSession(user: IUser): void {
    localStorage.setItem('user', JSON.stringify(user));
  }

  private setCurrentUser(user: IUser): void {
    this.currentUserSource.next(user);
  }
}
