import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITextQuestion } from '../courses/models/text-questions/text-question';
import { ITextQuestionCreate } from '../courses/models/text-questions/text-question-create';

@Injectable({
  providedIn: 'root'
})
export class TextQuestionService {

  url: string = 'https://localhost:7271/rl/text-questions';

  constructor(private http: HttpClient) { }

  public deleteQuestion(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }

  public createQuestion(question: ITextQuestionCreate): Observable<ITextQuestion> {
    return this.http.post<ITextQuestion>(this.url + '/', question);
  }

  public updateQuestion(question: ITextQuestionCreate, textQuestionId: number): Observable<ITextQuestion> {
    return this.http.put<ITextQuestion>(this.url + '/' + textQuestionId, question);
  }

}
