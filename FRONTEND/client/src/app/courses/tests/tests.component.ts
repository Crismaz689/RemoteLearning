import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUser } from 'src/app/account/models/User';
import { RoleMapper } from 'src/app/_helpers/role-mapper';
import { Role } from 'src/app/_helpers/role.enum';
import { AccountService } from 'src/app/_services/account.service';
import { TestService } from 'src/app/_services/test.service';
import { ITest } from '../models/tests/test';
import { ITextQuestion } from '../models/text-questions/text-question';
import { TestCreateComponent } from './test-create/test-create.component';
import { TestUpdateComponent } from './test-update/test-update.component';
import { TestComponent } from './test/test.component';
import { TextQuestionCreateComponent } from './text-questions/text-question-create/text-question-create.component';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.scss']
})
export class TestsComponent implements OnInit {

  @Input()
  courseId: number;

  @Input()
  creatorId: number;

  @Input()
  tests: ITest[] = [];

  @Output()
  testCreatedEvent = new EventEmitter<boolean>();

  @Output()
  questionCreatedEvent = new EventEmitter<boolean>();

  @Output()
  testUpdatedEvent = new EventEmitter<boolean>();

  currentUser: IUser;

  userRole = Role.Undefined;

  role = Role;
  
  constructor(private testService: TestService,
    private accountService: AccountService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe((user) => {
      this.currentUser = user;
      this.userRole = RoleMapper.RoleMapping(this.currentUser.roleName);
    });
  }

  openCreateTestDialog(): void {
    const dialog = this.dialog.open(TestCreateComponent);
    dialog.componentInstance.courseId = this.courseId;
    dialog.componentInstance.creatorId = this.creatorId;

    dialog.afterClosed().subscribe((isCreated) => {
      if (isCreated) {
        this.testCreatedEvent.emit(isCreated);
      }
    });
  }

  openEditTestDialog(test: ITest): void {
    const dialog = this.dialog.open(TestUpdateComponent);
    dialog.componentInstance.courseId = this.courseId;
    dialog.componentInstance.creatorId = this.creatorId;
    dialog.componentInstance.selectedTest = test;

    dialog.afterClosed().subscribe((isUpdated) => {
      if (isUpdated) {
        this.testUpdatedEvent.emit(isUpdated);
      }
    });
  }

  deleteTest(testId: number): void {
    this.testService.deleteTest(testId).subscribe((isDeleted) => {
      if (isDeleted) {
        this.snackBar.open("Test usunięty.", '', { panelClass: ['text-white', 'bg-success'] });
        const sectionIndex = this.tests.findIndex((test) => test.id === testId);
        this.tests.splice(sectionIndex, 1);
      }
      else {
        this.snackBar.open("Błąd podczas usuwania testu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Nie możesz usunąć tego testu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  refreshTestDetails(question: ITextQuestion): void {
    const testIndex = this.tests.findIndex((test) => {
      return test.textQuestions.find((q) => q.id === question.id);
    });

    this.tests[testIndex].points = this.tests[testIndex].points - question.points;
    this.tests[testIndex].timeMinutes = this.tests[testIndex].timeMinutes - question.timeMinutes;

    const questionIndex = this.tests[testIndex].textQuestions.findIndex((q) => q.id === question.id);
    this.tests[testIndex].textQuestions.splice(questionIndex, 1);
  }

  openTest(test: ITest): void {
    if (test.textQuestions.length > 0) {
      const dialog = this.dialog.open(TestComponent);
      dialog.componentInstance.test = test;
  
      dialog.afterClosed().subscribe(() => {});
    }
    else {
      this.snackBar.open("Nie można podejść do testu, ponieważ jest pusty. Poczekaj aż zostaną dodane do niego pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
    }
  }

  openAddTextQuestionDialog(testId: number): void {
    const dialog = this.dialog.open(TextQuestionCreateComponent);
    dialog.componentInstance.testId = testId;
    dialog.componentInstance.creatorId = this.creatorId;

    dialog.afterClosed().subscribe((isCreated) => {
      if (isCreated) {
        this.questionCreatedEvent.emit(isCreated);
      }
    });
  }

}
