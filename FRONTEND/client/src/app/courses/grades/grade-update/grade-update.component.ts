import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CategoryService } from 'src/app/_services/category.service';
import { CourseAssignmentService } from 'src/app/_services/course-assignment.service';
import { GradeService } from 'src/app/_services/grade.service';
import { ICategory } from '../../models/categories/category';
import { ICourseAssignment } from '../../models/course-assignments/course-assignment';
import { IGrade } from '../../models/grades/grade';
import { IGradeCreate } from '../../models/grades/grade-create';
import { ITest } from '../../models/tests/test';

@Component({
  selector: 'app-grade-update',
  templateUrl: './grade-update.component.html',
  styleUrls: ['./grade-update.component.scss']
})
export class GradeUpdateComponent implements OnInit {
  public tests: ITest[] = [];

  public courseId: number;

  updateGradeForm: FormGroup;

  categories: ICategory[] = [];

  userAssignments: ICourseAssignment[] = [];

  selectedGrade: IGrade;

  grade: number = 0;

  constructor(private gradeService: GradeService,
    private categoryService: CategoryService,
    private courseAssignmentService: CourseAssignmentService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar) {
    this.updateGradeForm = this.formBuilder.group({
      value: ['', [Validators.required, Validators.min(0)]],
      title: ['', [Validators.required, Validators.minLength(3)]],
      description: [''],
      userId: ['', Validators.required],
      categoryId: ['', Validators.required]
    });
   }

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe((categories) => {
      this.categories = categories;
    });

    this.courseAssignmentService.getCourseAssignments(this.courseId).subscribe((assignments) => {
      this.userAssignments = assignments;
    });
  }

  ngAfterContentInit(): void {
    this.grade = this.selectedGrade.value;
    this.updateGradeForm = this.formBuilder.group({
      value: [this.selectedGrade?.value, [Validators.required, Validators.min(0)]],
      title: [this.selectedGrade?.title, [Validators.required, Validators.minLength(3)]],
      description: [this.selectedGrade?.description],
      userId: [this.selectedGrade?.userId, Validators.required],
      categoryId: [this.selectedGrade?.categoryId, Validators.required]
    });
  }

  verifyGrade(): void {
    this.grade = parseInt(this.grade.toString());

    if (Number.isNaN(this.grade) || this.grade < 0) {
      this.grade = 0;
    }
  }

  updateGrade(): void {
    const updatedGrade: IGradeCreate = this.updateGradeForm.getRawValue();
    updatedGrade.courseId = this.courseId;

    this.gradeService.updateGrade(updatedGrade, this.selectedGrade.id).subscribe((grade) => {
      if (grade) {
        this.snackBar.open("Ocena zostałą zaktualizowana.", '', { panelClass: ['text-white', 'bg-success'] }); 
        location.reload();
      }
      else {
        this.snackBar.open("Nie udało się zaktualizować oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas aktualizacji oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }


}
