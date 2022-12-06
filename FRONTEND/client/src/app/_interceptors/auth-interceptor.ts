import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IUser } from '../account/models/User';

@Injectable({
    providedIn: 'root'
  })
  export class AuthInterceptor implements HttpInterceptor {
  
    constructor() {}
  
    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {  
      const user : IUser = JSON.parse(localStorage.getItem("user") ?? '');

      if (user) {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${user.token}`
          }
        })
      }
      return next.handle(request);
    }
  }