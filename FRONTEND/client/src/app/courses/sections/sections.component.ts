import { EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUser } from 'src/app/account/models/User';
import { AccountService } from 'src/app/_services/account.service';
import { SectionService } from 'src/app/_services/section.service';
import { ISection } from '../models/sections/section';
import { SectionCreateComponent } from './section-create/section-create.component';
import { SectionUpdateComponent } from './section-update/section-update.component';

@Component({
  selector: 'app-sections',
  templateUrl: './sections.component.html',
  styleUrls: ['./sections.component.scss']
})
export class SectionsComponent implements OnInit {

  @Input()
  sections: ISection[] = [];

  @Input()
  courseId!: number;

  @Input()
  creatorId!: number;

  @Output()
  sectionCreatedEvent = new EventEmitter<boolean>();

  @Output()
  sectionUpdatedEvent = new EventEmitter<boolean>();

  currentUser: IUser;

  constructor(private sectionService: SectionService,
    private accountService: AccountService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe((user) => {
      this.currentUser = user;
    });
  }

  openCreateSectionDialog(): void {
    const dialog = this.dialog.open(SectionCreateComponent);
    dialog.componentInstance.courseId = this.courseId;

    dialog.afterClosed().subscribe((isCreated) => {
      if (isCreated) {
        this.sectionCreatedEvent.emit(isCreated);
      }
    });
  }

  openEditSectionDialog(section: ISection): void {
    const dialog = this.dialog.open(SectionUpdateComponent);
    dialog.componentInstance.selectedSection = section;

    dialog.afterClosed().subscribe((isUpdated) => {
      if (isUpdated) {
        this.sectionUpdatedEvent.emit(isUpdated);
      }
    });
  }

  deleteSection(sectionId: number): void {
    this.sectionService.deleteSection(sectionId).subscribe((isDeleted) => {
      if (isDeleted) {
        this.snackBar.open("Sekcja usunięta.", '', { panelClass: ['text-white', 'bg-success'] });
        const sectionIndex = this.sections.findIndex((section) => section.id === sectionId);
        this.sections.splice(sectionIndex, 1);
      }
      else {
        this.snackBar.open("Błąd podczas usuwania sekcji.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Nie możesz usunąć tej sekcji.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
