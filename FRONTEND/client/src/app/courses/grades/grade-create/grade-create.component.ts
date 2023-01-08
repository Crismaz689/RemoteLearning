import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CategoryService } from 'src/app/_services/category.service';
import { CourseAssignmentService } from 'src/app/_services/course-assignment.service';
import { GradeService } from 'src/app/_services/grade.service';
import { ICategory } from '../../models/categories/category';
import { ICourseAssignment } from '../../models/course-assignments/course-assignment';
import { IGradeCreate } from '../../models/grades/grade-create';
import { ITest } from '../../models/tests/test';

@Component({
  selector: 'app-grade-create',
  templateUrl: './grade-create.component.html',
  styleUrls: ['./grade-create.component.scss']
})
export class GradeCreateComponent implements OnInit {
  public tests: ITest[] = [];

  public courseId: number;

  createGradeForm: FormGroup;

  categories: ICategory[] = [];

  userAssignments: ICourseAssignment[] = [];

  grade: number = 0;

  constructor(private gradeService: GradeService,
    private categoryService: CategoryService,
    private courseAssignmentService: CourseAssignmentService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar) {
    this.createGradeForm = this.formBuilder.group({
      value: ['', [Validators.required, Validators.min(0)]],
      title: ['', [Validators.required, Validators.minLength(3)]],
      description: [''],
      userId: ['', Validators.required],
      categoryId: ['', Validators.required]
    });
   }

  ngOnInit(): void {
    document.getElementById("value")?.focus();

    this.categoryService.getAllCategories().subscribe((categories) => {
      this.categories = categories;
    });

    this.courseAssignmentService.getCourseAssignments(this.courseId).subscribe((assignments) => {
      this.userAssignments = assignments;
    });
  }

  verifyGrade(): void {
    this.grade = parseInt(this.grade.toString());

    if (Number.isNaN(this.grade) || this.grade < 0) {
      this.grade = 0;
    }
  }

  createGrade(): void {
    const newGrade: IGradeCreate = this.createGradeForm.getRawValue();
    newGrade.courseId = this.courseId;

    this.gradeService.createGrade(newGrade).subscribe((grade) => {
      if (grade) {
        this.snackBar.open("Ocena zostałą dodana.", '', { panelClass: ['text-white', 'bg-success'] }); 
      }
      else {
        this.snackBar.open("Nie udało się dodać oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas dodawania oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
