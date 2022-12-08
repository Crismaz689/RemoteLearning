import { Component, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CourseService } from 'src/app/_services/course.service';
import { ICourseCreate } from '../models/course-create';

@Component({
  selector: 'app-course-create',
  templateUrl: './course-create.component.html',
  styleUrls: ['./course-create.component.scss']
})
export class CourseCreateComponent implements OnInit {

  createCourseForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private courseService: CourseService,
    private router: Router,
    private snackBar: MatSnackBar) { 
    this.createCourseForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      description: ['']
    });
  }

  ngOnInit(): void {
    document.getElementById("courseName")?.focus();
  }

  createCourse(): void {
    const newCourse: ICourseCreate = this.createCourseForm.getRawValue();

    this.courseService.create(newCourse).subscribe((course) => {
      if (course) {
        this.snackBar.open("Kurs " + course.name + " zostal stworzony", '', { panelClass: ['text-white', 'bg-success'] });
        this.router.navigateByUrl('/courses');
      }
      else {
        this.snackBar.open("Nie udało sie utworzyć kursu! Spróbuj z inną nazwą.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
        this.snackBar.open("Nie udało sie utworzyć kursu! Spróbuj z inną nazwą.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}