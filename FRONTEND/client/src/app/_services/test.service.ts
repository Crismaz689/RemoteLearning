import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITest } from '../courses/models/tests/test';
import { ITestAdmin } from '../courses/models/tests/test-admin';
import { ITestCreate } from '../courses/models/tests/test-create';
import { ITestForReview } from '../courses/models/tests/test-for-review';
import { ITestForStudent } from '../courses/models/tests/test-for-student';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  url: string = 'https://localhost:7271/rl/tests';

  constructor(private http: HttpClient) { }

  public sendAnswers(test: ITestForReview): Observable<boolean> {
    return this.http.post<boolean>(this.url + '/confirm', test);
  }

  public getTestForStudent(testId: number): Observable<ITestForStudent> {
    return this.http.get<ITestForStudent>(this.url + '/take-test/' + testId);
  }

  public getAdminAllTests(): Observable<ITestAdmin[]> {
    return this.http.get<ITestAdmin[]>(this.url + '/admin-get-all');
  }

  public wasTestTaken(testId: number): Observable<boolean> {
    return this.http.get<boolean>(this.url + '/was-taken/' + testId);
  }

  public deleteTest(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }

  public createTest(test: ITestCreate): Observable<ITest> {
    return this.http.post<ITest>(this.url + '/', test);
  }

  public updateTest(test: ITestCreate, testId: number): Observable<ITest> {
    return this.http.put<ITest>(this.url + '/' + testId, test);
  }
}
