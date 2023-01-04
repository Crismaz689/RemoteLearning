import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SectionService } from 'src/app/_services/section.service';
import { ISection } from '../../models/sections/section';
import { ISectionCreate } from '../../models/sections/section-create';

@Component({
  selector: 'app-section-create',
  templateUrl: './section-create.component.html',
  styleUrls: ['./section-create.component.scss']
})
export class SectionCreateComponent implements OnInit {

  public courseId: number;

  createSectionForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private sectionService: SectionService) { 
    this.createSectionForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      description: [''],
      date: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    document.getElementById("sectionName")?.focus();
  }

  createSection(): void {
    const newSection: ISectionCreate = this.createSectionForm.getRawValue();
    newSection.courseId = this.courseId;

    this.sectionService.createSection(newSection).subscribe((section) => {
      if (section) {
        this.snackBar.open("Sekcja stworzona.", '', { panelClass: ['text-white', 'bg-success'] });
        
      }
      else {
        this.snackBar.open("Nie udało się utworzyć sekcji.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas tworzenia sekcji.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}