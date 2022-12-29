import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from 'src/app/_services/course.service';
import { ICourseAllData } from '../models/course-all-data';
import { ICourseCreate } from '../models/course-create';

@Component({
  selector: 'app-course-update',
  templateUrl: './course-update.component.html',
  styleUrls: ['./course-update.component.scss']
})
export class CourseUpdateComponent implements OnInit {

  editCourseForm: FormGroup;

  course!: ICourseAllData;

  constructor(private formBuilder: FormBuilder,
    private courseService: CourseService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar) { 
    this.editCourseForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      description: ['']
    });
  }

  ngOnInit(): void {
    const courseId: number = (this.route.snapshot.paramMap.get('id') ?? 0) as number;

    this.courseService.getCourse(courseId).subscribe((course) => {
      if (course) {
        this.course = course;
        this.editCourseForm = this.formBuilder.group({
          name: [this.course.name, [Validators.required, Validators.minLength(3)]],
          description: [this.course.description]
        });
      }
    },
    (err) => {
      this.router.navigateByUrl('/courses');
      this.snackBar.open("Nie odnaleziono kursu. Zostałeś przekierowany na stronę główną.", '', { panelClass: ['text-white', 'bg-danger'] });
    })
  }

  editCourse(): void {
    const course: ICourseCreate = this.editCourseForm.getRawValue();

    this.courseService.create(course).subscribe((course) => {
      if (course) {
        this.snackBar.open("Kurs " + course.name + " zostal zaktualizowany", '', { panelClass: ['text-white', 'bg-success'] });
        this.router.navigateByUrl('/courses');
      }
      else {
        this.snackBar.open("Nie udało sie edytować kursu! Spróbuj z inną nazwą.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
        this.snackBar.open("Nie udało sie edytować kursu! Spróbuj z inną nazwą.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
