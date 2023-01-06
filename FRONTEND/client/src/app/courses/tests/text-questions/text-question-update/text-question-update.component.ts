import { AfterContentInit, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ITextQuestion } from 'src/app/courses/models/text-questions/text-question';
import { ITextQuestionCreate } from 'src/app/courses/models/text-questions/text-question-create';
import { TextQuestionService } from 'src/app/_services/text-question.service';

@Component({
  selector: 'app-text-question-update',
  templateUrl: './text-question-update.component.html',
  styleUrls: ['./text-question-update.component.scss']
})
export class TextQuestionUpdateComponent implements AfterContentInit {

  public selectedQuestion: ITextQuestion;

  editTextQuestionForm: FormGroup;

  time: number = 1;

  constructor(private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private textQuestionService: TextQuestionService) { 
    this.editTextQuestionForm = this.formBuilder.group({
      title: ['', [Validators.required, Validators.minLength(5)]],
      correctAnswer: ['', [Validators.required]],
      wrongAnswerA: ['', [Validators.required]],
      wrongAnswerB: ['', [Validators.required]],
      wrongAnswerC: ['', [Validators.required]],
      points: ['', [Validators.required, Validators.min(0.01)]],
      time: ['', [Validators.required]],
    });
  }

  ngAfterContentInit(): void {
    this.editTextQuestionForm = this.formBuilder.group({
      title: [this?.selectedQuestion?.title, [Validators.required, Validators.minLength(5)]],
      correctAnswer: [this?.selectedQuestion?.correctAnswer, [Validators.required]],
      wrongAnswerA: [this?.selectedQuestion?.wrongAnswerA, [Validators.required]],
      wrongAnswerB: [this?.selectedQuestion?.wrongAnswerB, [Validators.required]],
      wrongAnswerC: [this?.selectedQuestion?.wrongAnswerC, [Validators.required]],
      points: [this?.selectedQuestion?.points, [Validators.required, Validators.min(0.01)]],
      time: [this?.selectedQuestion?.timeMinutes, [Validators.required]],
    });
  }

  verifyTime(): void {
    this.time = parseInt(this.time.toString());

    if (Number.isNaN(this.time) || this.time < 1) {
      this.time = 1;
    }
  }

  editQuestion(): void {
    const question: ITextQuestionCreate = this.editTextQuestionForm.getRawValue();
    question.testId = this.selectedQuestion.testId;
    question.creatorId = this.selectedQuestion.creatorId;
    question.timeMinutes = this.time;

    this.textQuestionService.updateQuestion(question, this.selectedQuestion.id).subscribe((quest) => {
      if (quest) {
        this.snackBar.open("Pytanie zaktualizowane.", '', { panelClass: ['text-white', 'bg-success'] });
        location.reload();
      }
      else {
        this.snackBar.open("Nie udało się zaktualizować pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas aktualizacji pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
