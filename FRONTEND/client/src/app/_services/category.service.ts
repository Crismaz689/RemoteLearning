import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../courses/models/categories/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  url: string = 'https://localhost:7271/rl/categories';

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this.url + '/');
  }
}
