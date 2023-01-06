import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUser } from 'src/app/account/models/User';
import { Role } from 'src/app/_helpers/role.enum';
import { TextQuestionService } from 'src/app/_services/text-question.service';
import { ITextQuestion } from '../../models/text-questions/text-question';
import { TextQuestionUpdateComponent } from './text-question-update/text-question-update.component';

@Component({
  selector: 'app-text-questions',
  templateUrl: './text-questions.component.html',
  styleUrls: ['./text-questions.component.scss']
})
export class TextQuestionsComponent {

  @Input()
  textQuestions: ITextQuestion[] = [];

  @Input()
  courseId: number;

  @Input()
  creatorId: number;

  @Input()
  currentUser: IUser;

  @Input()
  userRole = Role.Undefined;

  @Output()
  textQuestionDeletedEvent = new EventEmitter<ITextQuestion>();

  isCollapsed: boolean = false;

  role = Role;
  
  constructor(private textQuestionService: TextQuestionService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  showQuestions(): void {
    this.isCollapsed = !this.isCollapsed;
  }

  openEditTextQuestionDialog(question: ITextQuestion): void {
    const dialog = this.dialog.open(TextQuestionUpdateComponent);
    dialog.componentInstance.selectedQuestion = question

    dialog.afterClosed().subscribe((isUpdated) => {});
  }

  deleteQuestion(questionId: number): void {
    this.textQuestionService.deleteQuestion(questionId).subscribe((isDeleted) => {
      if (isDeleted) {
        this.snackBar.open("Pytanie usunięte.", '', { panelClass: ['text-white', 'bg-success'] });
        const question = this.textQuestions.find((question) => question.id === questionId);
        this.textQuestionDeletedEvent.emit(question)
      }
      else {
        this.snackBar.open("Błąd podczas usuwania pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Nie możesz usunąć tego pytania.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
