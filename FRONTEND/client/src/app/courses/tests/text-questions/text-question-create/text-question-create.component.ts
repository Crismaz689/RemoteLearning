import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ITextQuestion } from 'src/app/courses/models/text-questions/text-question';
import { ITextQuestionCreate } from 'src/app/courses/models/text-questions/text-question-create';
import { TextQuestionService } from 'src/app/_services/text-question.service';

@Component({
  selector: 'app-text-question-create',
  templateUrl: './text-question-create.component.html',
  styleUrls: ['./text-question-create.component.scss']
})
export class TextQuestionCreateComponent implements OnInit {

  public testId: number;

  public creatorId: number;

  time: number = 1;

  createTextQuestionForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private textQuestionService: TextQuestionService) { 
    this.createTextQuestionForm = this.formBuilder.group({
      title: ['', [Validators.required, Validators.minLength(5)]],
      correctAnswer: ['', [Validators.required]],
      wrongAnswerA: ['', [Validators.required]],
      wrongAnswerB: ['', [Validators.required]],
      wrongAnswerC: ['', [Validators.required]],
      points: ['', [Validators.required, Validators.min(0.01)]],
      time: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    document.getElementById("title")?.focus();
  }

  verifyTime(): void {
    this.time = parseInt(this.time.toString());

    if (Number.isNaN(this.time) || this.time < 1) {
      this.time = 1;
    }
  }

  createQuestion(): void {
    const question: ITextQuestionCreate = this.createTextQuestionForm.getRawValue();
    question.creatorId = this.creatorId;
    question.testId = this.testId;

    this.textQuestionService.createQuestion(question).subscribe((quest) => {
      if (quest) {
        this.snackBar.open("Pytanie dodane.", '', { panelClass: ['text-white', 'bg-success'] });   
      }
      else {
        this.snackBar.open("Nie udało się utworzyć pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas tworzenia pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
