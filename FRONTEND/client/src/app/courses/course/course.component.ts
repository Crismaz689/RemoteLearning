import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from 'src/app/_services/course.service';
import { ICourseAllData } from '../models/course-all-data';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  course!: ICourseAllData;

  isSpinning: boolean = true;

  constructor(private courseService: CourseService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    const courseId: number = (this.route.snapshot.paramMap.get('id') ?? 0) as number;
    this.courseService.getCourse(courseId).subscribe((course) => {
      if (course) {
        this.course = course;
        this.isSpinning = false;
      }
    },
    (err) => {
      this.snackBar.open('Aby zajrzeć do kursu musisz być do niego przypisanym.', '', { panelClass: ['text-white', 'bg-danger'] });
      this.router.navigateByUrl('/homepage');
    });
  }

}
