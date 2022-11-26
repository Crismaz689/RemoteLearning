import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ILogin } from '../account/models/login'
import { IUser } from '../account/models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private currentUserSource = new BehaviorSubject<IUser | null>(null);

  url: string = 'https://localhost:7271/rl/';

  currentUser = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) { }

  login(credentials: ILogin): Observable<IUser> {
    return this.http.post<IUser>(this.url + 'accounts/login', credentials);
  }

  setSession(user: IUser): void {
    localStorage.setItem('id_token', user.token);
    localStorage.setItem('id_user', user.id.toString());
    localStorage.setItem('username', user.username);
    localStorage.setItem('roleName', user.roleName);

  }

  setCurrentUser(user: IUser): void {
    this.currentUserSource.next(user);
  }

  logout(): void {
    localStorage.clear();
    this.currentUserSource.next(null);
  }
}
