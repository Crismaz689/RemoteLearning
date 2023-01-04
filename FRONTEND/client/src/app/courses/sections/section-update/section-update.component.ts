import { formatDate } from '@angular/common';
import { AfterContentInit, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SectionService } from 'src/app/_services/section.service';
import { ISection } from '../../models/sections/section';
import { ISectionCreate } from '../../models/sections/section-create';

@Component({
  selector: 'app-section-update',
  templateUrl: './section-update.component.html',
  styleUrls: ['./section-update.component.scss']
})
export class SectionUpdateComponent implements AfterContentInit{

  public selectedSection: ISection;

  editSectionForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private sectionService: SectionService) { 
    this.editSectionForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      description: [''],
      date: ['', [Validators.required]]
    });
  }

  ngAfterContentInit(): void {
    this.editSectionForm = this.formBuilder.group({
      name: [this.selectedSection?.name, [Validators.required, Validators.minLength(3)]],
      description: [this.selectedSection?.description],
      date: [formatDate(this.selectedSection?.date, 'yyyy-MM-dd', 'en'), [Validators.required]]
    });
  }

  editSection(): void {
    const section: ISectionCreate = this.editSectionForm.getRawValue();

    this.sectionService.updateSection(section, this.selectedSection.id).subscribe((section) => {
      if (section) {
        this.snackBar.open("Sekcja zaktualizowana.", '', { panelClass: ['text-white', 'bg-success'] });
        
      }
      else {
        this.snackBar.open("Nie udało się zaktualizować sekcji.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas aktualizacji sekcji.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
