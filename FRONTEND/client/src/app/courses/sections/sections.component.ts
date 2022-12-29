import { Input } from '@angular/core';
import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SectionService } from 'src/app/_services/section.service';
import { ISection } from '../models/sections/section';

@Component({
  selector: 'app-sections',
  templateUrl: './sections.component.html',
  styleUrls: ['./sections.component.scss']
})
export class SectionsComponent {

  @Input()
  sections: ISection[] = [];

  @Input()
  courseId!: number;

  constructor(private sectionService: SectionService,
    private snackBar: MatSnackBar) { }

  createSection(): void {

  }

  editSection(section: ISection): void {

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
