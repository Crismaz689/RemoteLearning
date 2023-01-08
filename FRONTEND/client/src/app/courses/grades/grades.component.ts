import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUser } from 'src/app/account/models/User';
import { RoleMapper } from 'src/app/_helpers/role-mapper';
import { Role } from 'src/app/_helpers/role.enum';
import { AccountService } from 'src/app/_services/account.service';
import { GradeService } from 'src/app/_services/grade.service';
import { IGrade } from '../models/grades/grade';
import { ITest } from '../models/tests/test';
import { GradeCreateComponent } from './grade-create/grade-create.component';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.scss']
})
export class GradesComponent implements OnInit {

  @Input()
  courseId: number;

  @Input()
  creatorId: number;

  @Input()
  grades: IGrade[] = [];

  @Input()
  tests: ITest[] = [];

  @Output()
  gradeCreatedEvent = new EventEmitter<boolean>();

  currentUser: IUser;

  userRole = Role.Undefined;

  role = Role;
  
  constructor(private gradeService: GradeService,
    private accountService: AccountService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe((user) => {
      this.currentUser = user;
      this.userRole = RoleMapper.RoleMapping(this.currentUser?.roleName);
    });
  }

  openCreateGradeDialog(): void {
    const dialog = this.dialog.open(GradeCreateComponent);
    dialog.componentInstance.tests = this.tests;
    dialog.componentInstance.courseId = this.courseId;
    console.log(this.courseId);

    dialog.afterClosed().subscribe((isCreated) => {
      if (isCreated) {
        this.gradeCreatedEvent.emit(isCreated);
      }
    });
  }

}
