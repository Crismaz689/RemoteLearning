import { AfterContentInit, Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TestService } from 'src/app/_services/test.service';
import { ITestForReview } from '../../models/tests/test-for-review';
import { ITestForStudent } from '../../models/tests/test-for-student';
import { ITextQuestionAnswer } from '../../models/text-questions/text-question-answer';
import { ITextQuestionForStudent } from '../../models/text-questions/text-question-for-student';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements AfterContentInit {

  @Input()
  testId: number;
  
  test: ITestForStudent;

  currentQuestion: ITextQuestionForStudent;

  currentQuestionIndex: number = 0;

  textQuestionsAnswers: ITextQuestionAnswer[] = [];

  isSpinning: boolean = true;

  testForm: FormGroup;

  seconds: number = 100;

  counter: any;
  
  constructor(private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private testService: TestService) { 
    this.testForm = this.formBuilder.group({
      answer: [null, [Validators.required]]
    });
  }

  ngAfterContentInit(): void {
    this.testService.getTestForStudent(this.testId).subscribe((test) => {
      this.test = test;
      this.isSpinning = false;
      this.currentQuestion = this.test?.textQuestions[this.currentQuestionIndex];
      this.createTimer();
    });
  }

  nextQuestion(): void {
    const answer: ITextQuestionAnswer = this.testForm.getRawValue();
    answer.id = this.currentQuestion.id;
    this.textQuestionsAnswers.push(answer);

    if (this.currentQuestionIndex + 1 !== this.test?.textQuestions?.length) {
      this.refreshToNextQuestion();
    }
    else {
      this.finishTest(false);
    }
  }

  refreshToNextQuestion(): void {
    this.currentQuestionIndex = this.currentQuestionIndex + 1;
    this.currentQuestion = this.test?.textQuestions[this.currentQuestionIndex];
    this.currentQuestion
    this.testForm = this.formBuilder.group({
      answer: [null, [Validators.required]]
    });
  }

  createTimer(): void {
    this.counter = setInterval(() => {
      if(this.seconds > 0) {
        this.seconds--;
      } else {
        this.finishTest(true);
      }
    },1000);
  }

  finishTest(endOfTime: boolean): void {
    if (endOfTime) {
      this.snackBar.open("Skończył Ci się czas, test zakończony", '', { panelClass: ['text-white', 'bg-danger'] });
    }
    else {
      this.snackBar.open("Zakończyłeś test pomyślnie.", '', { panelClass: ['text-white', 'bg-success'] });
    }

    const finishedTest: ITestForReview = {
      testId: this.test.id,
      answers: this.textQuestionsAnswers
    }

    this.testService.sendAnswers(finishedTest).subscribe(() => {
      location.reload();
    },
    (err) => {
      location.reload();
    });
  }

  minutesLeft(): number {
    return parseInt((this.seconds / 60).toString());
  }

  secondsLeft(): number {
    return parseInt((this.seconds % 60).toString());
  }
}
